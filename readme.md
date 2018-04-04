# Property Based Testing in F# with FsCheck (Talk Outline)

1. It's not easy 
2. The tooling isn't particularly great  
3. Why would I even bother then!

Why is it hard: it requires a mental shift from old paradigms. Since you are here attending a functional programming conference, it means at least in part that you appreciate the benefits of different approaches. 

Current state of the art: example based testing. Mix of integration tests and unit tests. 

Property based testing. What is a property? It's a relationship between the input and output of a function. Or, less abstract, is a condition that always holds true under the specified circumstances (in a context). E.g. the maximum of an array is always an element of that array. It's also larger or equal than anything else in the array. Or a business requirement: the value of items in a shopping cart should not be negative, even after applying discounts. Sainsbury's avocados example. Other examples: testing asynchronous code. Sometimes the path to a result is non deterministic. 

Random input/chaos. Try something a heck of a lot. With this approach we cover more from the input space. Why random? it's not entirely random, focuses on "usual culprits" like neutral elements or, shocker, null or empty values. It's not infallible. 

Not a complete replacement of value based testing.

## FsCheck 

1. Generates random input for test methods; they're actually named properties. By default each property is run with 100 input values.  
2. Use shrinkers - once they find a failure case, they shrink the input while the property still fails - to get the easiest input that invalidates the condition.
 