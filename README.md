Echovoice.JSON ![project-status](http://stillmaintained.com/echovoice/Echovoice.JSON.png)
==============

Echovoice JSON Array Encode, Decode and Pretty methods. Used internally until the public release of [WS3V](http://ws3v.org).

This library is available on Nuget as [Echovoice.JSON](https://www.nuget.org/packages/Echovoice.JSON/).


Why?
============================

Json.net was too big for simple JSON array encoding and decoding, plus the way to use it was far too complex.

JavascriptSerializer uses the odd JsonArray class, all we wanted was simple strings, arrays or numbers.


Decode Usage
============================

Simple JSON array to string array ```JSONDecoders.DecodeJsStringArray()```

```csharp
string input = "[\"philcollins\",\"Ih8PeterG\"]";
string[] result = JSONDecoders.DecodeJsStringArray(input);
```

result[0]: ```philcollins```
result[1]: ```Ih8PeterG```

Complex JSON Array ```JSONDecoders.DecodeJSONArray()```

```csharp
string input = "[14,4,[14,\"data\"],[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]]";
string[] result = JSONDecoders.DecodeJSONArray(input);
string[] result2 = JSONDecoders.DecodeJSONArray(result[3]);
```

result[0]: ```14```
result[1]: ```4```
result[2]: ```[14,"data"]```
result[3]: ```[[5,"10.186.122.15"],[6,"10.186.122.16"]]```


result2[0]: ```[5,"10.186.122.15"]```
result2[1]: ```[6,"10.186.122.16"]```


Encode Usage
============================

Simple object to JSON Array ```EncodeJsObjectArray()```

```csharp
public class dummyObject
{
    public string fake { get; set; }
    public int id { get; set; }

    public dummyObject()
    {
        fake = "dummy";
        id = 5;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append('[');
        sb.Append(id);
        sb.Append(',');
        sb.Append(JSONEncoders.EncodeJsString(fake));
        sb.Append(']');

        return sb.ToString();
    }
}

dummyObject[] dummys = new dummyObject[2];
dummys[0] = new dummyObject();
dummys[1] = new dummyObject();

dummys[0].fake = "mike";
dummys[0].id = 29;

string result = JSONEncoders.EncodeJsObjectArray(dummys);
```

Result: ```[[29,"mike"],[5,"dummy"]]```


Pretty Usage
============================

Pretty print JSON Array ```PrettyPrintJson()``` string extension method

```csharp
string input = "[14,4,[14,\"data\"],[[5,\"10.186.122.15\"],[6,\"10.186.122.16\"]]]";
string result = input.PrettyPrintJson();
```

Result:
```json
[
   14,
   4,
   [
      14,
      "data"
   ],
   [
      [
         5,
         "10.186.122.15"
      ],
      [
         6,
         "10.186.122.16"
      ]
   ]
]
```

