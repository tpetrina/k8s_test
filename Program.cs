// Load from in-cluster configuration:
using k8s;

try
{

    var config = KubernetesClientConfiguration.InClusterConfig();

    // Use the config object to create a client.
    var client = new Kubernetes(config);

    var namespaces = client.CoreV1.ListNamespace();
    foreach (var ns in namespaces.Items)
    {
        Console.WriteLine(ns.Metadata.Name);
        var list = client.CoreV1.ListNamespacedPod(ns.Metadata.Name);
        foreach (var item in list.Items)
        {
            Console.WriteLine(item.Metadata.Name);
        }
    }

    Console.WriteLine("Done");
}
catch (Exception ex)
{
    Console.WriteLine("Exception caught");
    Console.WriteLine(ex);
}