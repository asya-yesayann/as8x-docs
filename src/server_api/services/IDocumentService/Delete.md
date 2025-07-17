---
title: IDocumentService.Delete(int, bool, string, bool, bool) մեթոդ
---

```c#
public Task<DeletedDoc> Delete(int isn,
                               bool fullDelete,
                               string comment,
                               bool callDelete = true,
                               bool inheritedDelete = false)
```

Ջնջում է փաստաթուղթը համակարգից։  
Ջնջվող փաստաթղթերի համար առաջանում է [Delete](../../definitions/document.md#delete) իրադարձությունը, ապա փաստաթղթի վիճակը դառնում է 999, որից հետո այդ փաստաթուղթը հայտնվում է ջնջված փաստաթղթերի թղթապանակում։ 
Ջնջման ժամանակ հեռացվում են նաև այդ փաստաթղթի բոլոր թղթապանակները, ծառի տարրերը և իր համար գրանցված հաշվառումները։

Եթե փաստաթուղթը ունի ենթափաստաթղթեր, ապա ջնջումը չի կատարվի և կառաջանա սխալ։

Ջնջումը տեղի է ունենում տրանզակցիայի մեջ։

**Պարամետրեր**

* `isn` - Ջնջվող փաստաթղթի ներքին նույնականացման համարը:
* `fullDelete` - Փաստաթղթի վերջնական ջնջման հայտանիշ։  
  Վերջնական ջնջման ժամանակ փաստաթուղթը ջնջվում է բոլոր միջուկային աղյուսակներից՝ [DOCP](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocP.html), [FOLDERS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Folders.html), [TREES](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Trees.html), [HIPAR](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/HiPar.html), [HIREST](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest.html), [HIREST2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hirest2.html), [ACCESS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Access.html), [HI](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi.html) և [HI2](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Hi2.html)։  
  Ոչ վերջնական ջնջման ժամանակ փաստաթուղթը մնում է [DOCS](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docs.html), [DOCLOG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocLog.html), [DOCSG](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/DocsG.html), [DOCSIM](https://github.com/armsoft/as4x-docs/blob/master/HTM/ProgrGuide/Database/Docsim.html) աղյուսակների մեջ և վիճակը լինում է 999:
* `comment` - Փաստաթղթի պատմության մեջ գրանցվող ջնջման մեկնաբանություն։
* `callDelete` - Փաստաթղթի [Delete](../../definitions/document.md#delete) իրադարձությունը կանչելու հայտանիշ։ 
* `inheritedDelete` - `true` արժեքի դեպքում փաստաթղթի պատմության մեջ գրվում է, որ փաստաթուղթը ջնջվել է այլ փաստաթղթի ջնջման ընթացքում։ 
  Տվյալների պահոցում ջնջման կոդը լինում է `H`, հակառակ դեպքում `D`։
