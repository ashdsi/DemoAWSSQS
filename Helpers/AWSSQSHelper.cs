using Amazon.SQS;
using Amazon.SQS.Model;
using DemoAWSSQS.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoAWSSQS.Helpers
{
    public class AWSSQSHelper : IAWSSQSHelper
    {
        private readonly IAmazonSQS _sqs;
        private readonly ServiceConfiguration _settings;
        public AWSSQSHelper(IAmazonSQS sqs, IOptions<ServiceConfiguration> settings)
        {
            _sqs = sqs;
            _settings = settings.Value;
        }

        public object JsonConvert { get; private set; }

        public async Task<bool> DeleteMessageAsync(string messageReceiptHandle)
        {
            try
            {
                //Deletes the specified message from the specified queue  
                var deleteResult = await _sqs.DeleteMessageAsync(_settings.AWSSQS.QueueUrl, messageReceiptHandle);
                return deleteResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Message>> ReceiveMessageAsync()
        {
            try
            {
                //Create New instance  
                var request = new ReceiveMessageRequest
                {
                    QueueUrl = _settings.AWSSQS.QueueUrl,
                    MaxNumberOfMessages = 10,
                    WaitTimeSeconds = 5
                };
                //Check Is there any new message available to process  
                var result = await _sqs.ReceiveMessageAsync(request);

                return result.Messages.Any() ? result.Messages : new List<Message>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SendMessageAsync(UserDetail userDetail)
        {
            try
            {
                string message = JsonSerializer.Serialize(userDetail);
                var sendRequest = new SendMessageRequest(_settings.AWSSQS.QueueUrl, message);
                // Post message or payload to queue  
                var sendResult = await _sqs.SendMessageAsync(sendRequest);

                return sendResult.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
