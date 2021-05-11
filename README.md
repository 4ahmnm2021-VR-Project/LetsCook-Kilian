# LetsCook-Kilian

* Set Default Target Offset to 0,0001

* On SteamVR reinport or update insert into Hand.cs DetachObject function:

```ruby
#start of function
var tmpObj = currentAttachedObject;
#end of function
tmpObj.GetComponent<Rigidbody>().isKinematic = false;
 
```
