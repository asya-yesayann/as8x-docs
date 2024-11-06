---
layout: page
title: "Descriptor դաս" 
---

Դասը նախատեսված է համակարգային պարամետրի նկարագրման համար։

Օգտագործվում է [IParametersService](../services/IParametersService.md).[GetDescriptor](../services/IParametersService.md#getdescriptor) մեթոդում։

```c#
public sealed class Descriptor
{
    public string ParamID { get; private set; }
    public string ASType { get; private set; }
    public bool UserParam { get; private set; }
    public string SerializedValue { get; internal set; }
    public bool UseFromCache { get; private set; }
    public string Kind { get; private set; }
    public string Group { get; private set; }
    public string Description { get; private set; }
    public string EnglishDescription { get; private set; }
    public FieldType FieldType { get; private set; }
    public string UpAccess { get; private set; }    
}
```

* `ParamID` - Պարամետրի ներքին անունը (id):
* `ASType` - Պարամետրի [4X-ական համակարգային տիպը](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/types.html)։
* `UserParam` - Ցույց է տալիս, արդյոք պարամետրը կտրված է ըստ օգտագործողի, թե ոչ։
* `SerializedValue` - Պարամետրի արժեքը։
* `UseFromCache` - Պարամետրի քեշում պահման և քեշից արժեքը կարդալու հայտանիշ։
* `Kind` - Պարամետրի խումբը:
* `Group` - Պարամետրի խումբը, որը ընդունում է է արժեքներ **PARGROUP** ծառից։
* `Description` - Պարամետրի հայերեն նկարագրությունը։
* `EnglishDescription` - Պարամետրի անգլերեն նկարագրությունը։
* `FieldType` - Պարամետրի [համակարգային տիպը](system_types.md)։
* `UpAccess` - Պարամետրի խմբագրման թույլտվություն։
    * 0 - Խմբագրում թույլ չի տրվում Համակարգի պարամետրերի ուղղորդիչից։
    * 1 - Խմբագրում թույլ է տրվում միայն ադմինիստրատորին։
    * 2 - Խմբագրում թույլ է տրվում բոլոր օգտագործողներն։