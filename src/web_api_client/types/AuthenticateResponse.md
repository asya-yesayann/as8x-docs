---
layout: page
title: "AuthenticateResponse" 
---

Դասը պարունակում է նույնականացումը անցած կլիենտ ծրագրի և օգտագործողի տվյալները։

Օգտագործվում է [AuthenticationClient](../routes/AuthenticationClient.md).[AuthenticateWithSecretAsync](../routes/AuthenticationClient.md#authenticatewithsecretasync) մեթոդում։

```c#
public class CertificateAuthenticateResponse
{
    public short SUID { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public bool IsAdmin { get; set; }
    public string DbName { get; set; }
    public string Server { get; set; }
    public string SessionGuid { get; set; }
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public bool MustChangePassword { get; set; }
    public int? PasswordState { get; set; }
}
```

* `SUID` - Օգտագործողի ներքին համարը (կոդ)։
* `Username` - Օգտագործողի մուտքանունը։
* `Name` - Օգտագործողի անուն։
* `IsAdmin` - Օգտագործողի ադմինիստրատոր հանդիսանալու հայտանիշ։
* `DbName` - Տվյալների պահոցի անունը, որին միացված է օգտագործողը։
* `Server` - Տվյալների պահոցը պարունակող սերվերի անունը։
* `SessionGuid` - Օգտագործողի համակարգ մուտք գործման արդյունքում բացված [սեսսիայի](../../server_api/types/SessionInfo.md) id-ն։
* `Token` - Տոկեն, որը նախատեսված է օգտագործողի կողմից դեպի սերվիս կանչերի նույնականացման համար։
* `RefreshToken` - Հիմնական տոկենի վավերականության ժամկետի լրացումից հետո տրվող թարմացման տոկենը։
* `MustChangePassword` - Համակարգ մուտք գործելուց հետո օգտագործողը պետք է փոխի գաղտնաբառը, թե ոչ։
* `PasswordState` - Օգտագործողի գաղտնաբառի վիճակը։
    * 0 - Գաղտնաբառը վավեր է։
    * 1 - Գաղտնաբառը նշանակվել է ադմինի կողմից և ենթակա է փոփոխման:
    * 2 - Գաղտնաբառը ժամկետանց է։




