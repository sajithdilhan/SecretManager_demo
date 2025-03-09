using Amazon;
using Amazon.Runtime;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;


var awsCredentials = new BasicAWSCredentials("", "");
IAmazonSecretsManager secretsManager = new AmazonSecretsManagerClient(awsCredentials, RegionEndpoint.GetBySystemName("ap-southeast-1"));

GetSecretValueRequest svRequest = new GetSecretValueRequest()
{
    SecretId = "test_pw"
};

CancellationTokenSource cts = new CancellationTokenSource(2000);

try
{
    var res = await secretsManager.GetSecretValueAsync(svRequest, cts.Token);
    if (res != null)
    {
        Console.WriteLine(res.SecretString);

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}

