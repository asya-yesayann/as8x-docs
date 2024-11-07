---
layout: page
title: "CertificateAuthenticateRequest դաս" 
---

Դասը պարունակում է նույնականացման ենթակա սերտիֆիկատով կլիենտ ծրագրի և օգտագործողի տվյալները։

Օգտագործվում է [AuthenticationClient](../routes/AuthenticationClient.md).[AuthenticateWithCertificateAsync](../routes/AuthenticationClient.md#authenticatewithcertificateasync) մեթոդում։

```c#
public class CertificateAuthenticateRequest
{
    public byte[] Certificate { get; set; }
    public short ApiClientId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime? RequestTime { get; set; }
    public string TimeZoneId { get; set; }
}
```

* `Certificate` - Սերտիֆիկատով նույնականացվող կլիենտ ծրագրի սերտիֆիկատը։
* `ApiClientId` - Նույնականացվող կլիենտ ծրագրի id-ն։
* `Username` - Կլիենտ ծրագրի օգտագործողի ներքին անունը, որով նույնականացվում է։
* `Password` - Կլիենտ ծրագրի օգտագործողի գաղտնաբառը։
* `RequestTime` - Օգտագործողի նույնականացման հարցման ուղարկման ամսաթիվը/ժամանակը։
* `TimeZoneId` - Այն ժամային գոտու id-ն, որով աշխատում է օգտագործողը։