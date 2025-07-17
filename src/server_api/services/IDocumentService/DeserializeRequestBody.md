---
title: IDocumentService.DeserializeRequestBody(DocumentModel, bool) մեթոդ
---

```c#
public Task<Document> DeserializeRequestBody(DocumentModel request, bool isExtended = false)
```

նախատեսված է կլիենտից դեպի սերվեր փաստաթղթի ուղարկման ժամանակ դեսերիալիզազիայի և [Document](../../definitions/document.md) տիպի օբյեկտի վերածեու համար։  

Սովորաբար օգտագործվում է փաստաթղթի [DeserializeComplexObjects](../../definitions/document.md#deserializecomplexobjects) մշակիչի մեջ։

**Պարամետրեր**

* `request` - Փաստաթղթի ցանցով փոխանցվող օբյեկտ։
* `isExtended` - Ցույց է տալիս արդյոք փաստաթղթի դաշտերը պետք է բերվեն `ANSI` կոդավորման և հեռացվեն ավելորդ բացակները, թե ոչ։
