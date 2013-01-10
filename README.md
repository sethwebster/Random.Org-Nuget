# Random.Org Random Number Generator Client
---
### Installing:
	
	Install-Package Random.Org
	
### Usage

	Random.Org.Random r = new Random.Org.Random();
    var val = r.Next(1, 1000);
    Console.WriteLine(val);

### Test Usage

	Random.Org.Random r = new Random.Org.Random();
	r.UseLocalMode = true; // prevents external web call, useful for testing
    var val = r.Next(1, 1000);
    Console.WriteLine(val);
    
