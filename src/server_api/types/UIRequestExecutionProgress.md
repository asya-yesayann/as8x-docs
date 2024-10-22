---
layout: page
title: "UIRequestExecutionProgress" 
tags: Indicate, Progress
---

## Բովանդակություն

- [Ներածություն](#ներածություն)
- [Հատկություններ](#հատկություններ)
  - [UIRequestEnabled](#uirequestenabled)
- [Մեթոդներ](#մեթոդներ)
  - [MessageBox](#messagebox)
  - [MessageBox](#messagebox-1)

## Ներածություն

UIRequestExecutionProgress դասը նախատեսված է [DataSource](../definitions/ds.md), [DPR](../definitions/dpr.md), [Document](../definitions/document.md)-ի կատարման ընթացքում սերվերից կլիենտին [հաղորդագրություններ ուղարկելու](#messagebox) և պատասխանը ստանալու ֆունկցիոնալությունը ապահովելու համար։

## Հատկություններ

### UIRequestEnabled

```c#
public bool UIRequestEnabled { get; internal set; }
```

Ստուգում է արդյոք հասանելի է UI-ը թե ոչ։ Միայն UI-ի հասանելիության դեպքում է հնարավոր ցույց տալ սերվիսից եկող [հաղորդագրության պատուհանները](#messagebox)։

## Մեթոդներ

### MessageBox

```c#
public Task<MessageBoxResult> MessageBox(string prompt, MessageBoxButtons messageBoxButtons,
                                         MessageBoxIconType messageBoxIcon, MessageBoxDefaultButton messageBoxDefaultButton,
                                         string title, TimeSpan timeSpanToShow, int? id = null)
```

Այս մեթոդը օգտագործվում է [DataSource](../definitions/ds.md), [DPR](../definitions/dpr.md), [Document](../definitions/document.md)-ի կատարման ընթացքում 8X սերվիսից 4X կամ 8X կլիենտին հաղորդագրություն ուղարկելու, հաղորդագրության պատասխանը ստանալու և այն սերվիսում մշակելու համար։

**Պարամետրեր**

* `prompt` - Հաղորդագրության պատուհանի տեքստը։
* `messageBoxButtons` - [Հաղորդագրության պատուհանում ավելացվող կոճակները](MessageBoxButtons.md)։
* `messageBoxIcon` - [Հաղորդագրության պատուհանում ավելացվող պատկերակը](MessageBoxIconType.md)։ 
* `messageBoxDefaultButton` - [Հաղորդագրության պատուհանի լռությամբ կոճակը](MessageBoxDefaultButton.md)։ Պատուհանի էկրանին երևալու ժամանակը լրանալուն պես պատուհանը ավտոմատ փակվում է` սեղմելով լռությամբ ընտրված կոճակը։
* `title` - Հաղորդագրության պատուհանի գլխագիրը։ 
* `timeSpanToShow` - Հաղորդագրության պատուհանի էկրանին երևալու ժամանակը:
* `id` - Հաղորդագրության պատուհանի ներքին նույնականացման համարը (id):

### MessageBox

```c#
public Task<MessageBoxResult> MessageBox(string prompt, MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK,
                                         MessageBoxIconType messageBoxIcon = MessageBoxIconType.Default,
                                         MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.DefaultButton1,
                                         string title = "", int millisecondsToShow = 15000, int? id = null)
```

Այս մեթոդը օգտագործվում է [DataSource](../definitions/ds.md), [DPR](../definitions/dpr.md), [Document](../definitions/document.md)-ի կատարման ընթացքում 8X սերվիսից 4X կամ 8X կլիենտին հաղորդագրություն ուղարկելու, հաղորդագրության պատասխանը ստանալու և այն սերվիսում մշակելու համար։

**Պարամետրեր**

* `prompt` - Հաղորդագրության պատուհանի տեքստը։
* `messageBoxButtons` - [Հաղորդագրության պատուհանում ավելացվող կոճակները](MessageBoxButtons.md): Չլրացնելու դեպքում պատուհանում ավելացվելու է միայն "Լավ" կոճակը։
* `messageBoxIcon` - [Հաղորդագրության պատուհանում ավելացվող պատկերակը](MessageBoxIconType.md)։ Չլրացնելու դեպքում պատուհանում ավելացվելու է "Information Message" պատկերակը։
* `messageBoxDefaultButton` - [Հաղորդագրության պատուհանի լռությամբ կոճակը](MessageBoxDefaultButton.md)։ Պատուհանի էկրանին երևալու ժամանակը լրանալուն պես պատուհանը փակվում է ավտոմատ սեղմելով լռությամբ ընտրված կոճակը։ Չլրացնելու դեպքում լռությամբ կոճակ հանդիսանալու է ձախից առաջին կոճակը։
* `title` - Հաղորդագրության պատուհանի գլխագիրը։ Չլրացնելու դեպքում գլխագիր հանդիսանալու է ծրագրի անունը, օրինակ "ՀԾ Բանկ", "ՀԾ Ձեռնարկություն"...:
* `millisecondsToShow` - Հաղորդագրության պատուհանի էկրանին երևալու ժամանակը միլիվայրկյաններով: Չլրացնելու դեպքում պատուհանը փակվելու է 15 վրկ հետո՝ սեղմելով լռությամբ ընտրված կոճակը (`messageBoxDefaultButton`)։
* `id` - Հաղորդագրության պատուհանի ներքին նույնականացման համարը (id):

## Օրինակ

Այս օրինակում ներկայացված է  փաստաթղթի հեռացման տրանզակցիայում աշխատող [Delete](../definitions/document.md#delete) իրադարձության մշակիչում ուղարկվում է հաղորդագրություն սերվերից կլիենտին [MessageBox](#messagebox) մեթոդի միջոցով։

```c#
public override async Task Delete(DeleteEventArgs args)
{
  // բեռնում է "Պայմանագիր" փաստաթղթի զավակ փաստաթղթերը
  var childs = await this.DocumentService.GetDocumentChildren(this.ISN);

  if (childs.Count > 0)
  {
    // MessageBox մեթոդի կանչի արդյունքում կլիենտում բացվում է հաղոորդագրւթյան պատուհան
    // "Հեռացնել պայմանագրի հաշիվները" տեքստով և "Այո" կոճակ սեղմման դեպքում հեռացվում է "Պայմանագիր" փաստաթղթի
    // և իր զավակ "Հաշիվ" փաստաթղթերի միջև կապերը։
    if ((await this.Progress.MessageBox("Հեռացնել պայմանագրի հաշիվները".ToArmenianANSI()),
        MessageBoxButtons.YesNo, MessageBoxIconType.Question)).UIRequestResult == MessageBoxRequestResult.Yes)
    {
        foreach (var (childISN, _) in childs)
        {
            await this.DocumentService.CutParentLink(childISN, this.ISN);          
        }           
    }
  }
}
```
