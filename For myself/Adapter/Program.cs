using Adapter;
using Adapter.For_the_desert;

Driver driver = new Driver();
Auto auto = new Auto();
driver.Travel(auto);

//Met the sands, I must use a camel
Camel camel = new Camel();
ITransport adapter = new CamelToTransportAdapter(camel);
driver.Travel(adapter);




