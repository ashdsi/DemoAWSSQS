1. Create an SQS queue. Get the Queue URL
2. The queue URL has to be be stored in AWS Parameter store under the hierarchy 
Parameter name: /myqueue/ServiceConfiguration/AWSSQS/QueueUrl
Value: <Queue URL>

3. Postman API methods:

#Get all messages from queue
GET: http://localhost:5000/api/awssqs/getAllMessages

#Post message to queue
POST: http://localhost:5000/api/awssqs/postMessage
with Body: 
{
    "FirstName" : "<firstname>",
    "LastName" : "<lastname>",
    "UserName" : "<username>",
    "EmailId" : "<e-mail id>"
}

#Delete message from queue
DELETE: http://localhost:5000/api/awssqs/deleteMessage
with Body:
{
    "ReceiptHandle" : "<add the value from GET request>"
}

4. Build and Run the app: 
dotnet build
dotnet run