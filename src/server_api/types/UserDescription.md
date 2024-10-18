---
layout: page
title: "UserDescription" 
tags: User
---

Այս դասը նախատեսված է համակարգի օգտագործողի նկարագրման համար։

Օգտագործվում է [IUserService](../services/IUserService.md).[UserElProp](../services/IUserService.md#userelprop) մեթոդում։

```c#
public class UserDescription
{
    public short SUID { get; set; } = -1;
    public string Name { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public bool IsAdmin { get; set; }
    public bool LoginDisabled { get; set; }
    public bool IsHidden { get; set; }
    public int Expired { get; set; }
    public string SID { get; set; }
    public byte[] SidData { get; set; }
    public bool IsActiveDirectoryUser { get; set; }
    public bool IsSqlUser { get; set; }
}
```

* `SUID` - Օգտագործողի ներքին համար։
* `Name` - Օգտագործողի ներքին անուն, որը օգտագործվում է որպես մուտքանուն համակարգ մուտք գործելիս։
* `FullName` - Օգտագործողի լրիվ անուն:
* `Description` - Օգտագործողի նկարագրություն։
* `IsAdmin` - Օգտագործողի ադմինիստրատոր հանդիսանալու հայտանիշ։
* `LoginDisabled` - Օգտագործողի համակարգ մուտք գործելու թույլտվության հայտանիշ։
* `IsHidden` - Օգտագործողի անտեսանելի լինելու հայտանիշ։ `true` արժեքի դեպքում օգտագործողը չի երևում "Օգտագործողներ" հաշվետվությունում։
* `Expired` - Ցույց է տալիս, թե քանի օրից կլրանա օգտագործողի գաղտանաբառի վավերականության ժամկետը։ -1 արժեքի դեպքում գաղտանաբառը համարվում է միշտ վավեր։
* `SID` - SQL եղանակով նույնականացված օգտագործողի ներքին նույնականացման համարը։
* `SidData` - Active Directory եղանակով նույնականացված օգտագործողի ներքին նույնականացման համարը։
* `IsActiveDirectoryUser` - Ցույց է տալիս օգտագործողի նույնականացման եղանակը Active Directory տեսակի է, թե ոչ։
* `IsSqlUser` - Ցույց է տալիս օգտագործողի նույնականացման եղանակը SQL-ով է, թե ոչ։
