using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace LoanReceivingService
{
    public class SQSManager

    {
        private readonly AmazonSQSConfig sqsConfig;
        private readonly AmazonSQSClient sqsClient;
        public SQSManager()
        {


           // var chain = new CredentialProfileStoreChain(@"~/.aws/credentials");
         //   AWSCredentials awsCredentials;
          //  if (chain.TryGetAWSCredentials("development", out awsCredentials))
        //    {
            sqsClient = new AmazonSQSClient("AKIAI3MMTDG2HKAWJCPA", "kKqaZ1b/+DPyEGocUTnq1CJDowqnOGMLpciE/YTF",
                RegionEndpoint.USWest2);
            //    }



        }

        public async Task SendMessage()
        {
           ReceiveMessageRequest messageRequest = new ReceiveMessageRequest();
            messageRequest.QueueUrl = "https://sqs.us-west-2.amazonaws.com/456186057084/MortgageQueue";

         var messageResponse =   await sqsClient.ReceiveMessageAsync(messageRequest);
            sqsClient.Dispose();
            EmailService.SendEmail(messageResponse.Messages[0].Body);

        }

    }
}
