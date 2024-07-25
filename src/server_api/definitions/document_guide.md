---
layout: page
title: "(Document) Փաստաթղթի նկարագրման ձեռնարկ"
tags: [Document]
---

## Բովանդակություն

* [Նախաբան](#նախաբան)
* [Փաստաթղթի նկարագրման համար անհրաժեշտ քայլեր](#փաստաթղթի-նկարագրման-համար-անհրաժեշտ-քայլեր)
  * [.as ընդլայնմամբ ֆայլի սահմանում](#as-ընդլայնմամբ-ֆայլի-սահմանում)
  * [.cs ընդլայնմամբ ֆայլի սահմանում](#cs-ընդլայնմամբ-ֆայլի-սահմանում)
    * [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
    * [Նկարագրման հատվածի ձևավորում](#նկարագրման-հատվածի-ձևավորում)
    * [Մեթոդներ](#մեթոդներ)


## Նախաբան

8X-ում փաստաթղթի նկարագրության համար հարկավոր է ունենալ 
- .as ընդլայնմամբ ֆայլ սկրիպտերում [DOCUMENT](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/doc.html) նկարագրությամբ, որը պարունակում է մետատվյալներ փաստաթղթի մասին,
- .cs ընդլայնմամբ ֆայլ, որը պարունակում է սերվերում աշխատող տրամաբանությունը։ 

## Փաստաթղթի նկարագրման համար անհրաժեշտ քայլեր

## .as ընդլայնմամբ ֆայլի սահմանում

``` as4x
DOCUMENT {
  NAME = UsrAccs;
  CAPTION = "Օգտագործողի հաշիվներ";
  ECAPTION = "User's accounts";
  PROCESSINGMODE = 2;

Page { CAPTION = "Ընդհանուր";    ECAPTION = "General";
REKVIZIT {NAME = USERNAME;        CAPTION = "Օգտագործողի անուն";    ECAPTION="User's name";	     TYPE = C(20);   };
REKVIZIT {NAME = BRANCH;	  CAPTION = "Մասնաճյուղ";	    ECAPTION="Registration branch";  TYPE = C(10);  };

GRID {NAME = Accounts;	     CAPTION = "Հաշիվներ";              ECAPTION = "Accounts";     WIDTH = 13000; HEIGHT = 3000;
  COLUMN {NAME = ACCTYPE;   CAPTION = "Տիպ"; 		       ECAPTION = "Type"; 		      TYPE = C(10);	 };
  COLUMN {NAME = CODE;      CAPTION = "Կոդ";                    ECAPTION = "Code";	              TYPE = NP(16);	};
};

MEMO {NAME = COMMENT;      CAPTION = "Մեկնաբանություն";         ECAPTION = "Comment";     WIDTH = 7000;  HEIGHT = 2300;};
};
}
```

- Ստեղծել .as ընդլայնմամբ ֆայլ՝ ավելացնելով [DOCUMENT](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/doc.html) տիպի նկարագրություն, որը պարունակում է փաստաթղթի՝
  - NAME - Ներքին անունը։
  - CAPTION - Հայերեն անվանումը `ANSI` կոդավորմամբ։
  - ECAPTION - Անգլերեն անվանումը։
  - PROCESSINGMODE - Կատարման ռեժիմը։
- Ստեղծված ֆայլը ներմուծել տվյալների բազա `Syscon` գործիքով։

## .cs ընդլայնմամբ ֆայլի սահմանում

Ամբողջական կոդը դիտելու համար [տե՛ս](/src/server_api/examples/document_code.cs): 

- Հայտատարել դաս, որը ունի փաստաթղթի ներքին անվանումը պարունակող `Document` ատրիբուտը և  ժառանգում է [Document](document.md) դասը։

```c#
[Document("UsrAccs")]
public class UserAccounts : Document
```

### Կոնստրուկտորի ձևավորում

- Ձևավորել կոնստրուկտորը՝ IServiceProvider տիպի պարտադիր պարամետրով, որը պիտի կանչի base Document դասի կոնստրուկտորը և փոխանցի IServiceProvider տիպի պարամետրը: Կոնստուկտորում անհրաժեշտ է [ինյեկցիա](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) անել աշխատանքի համար անհրաժեշտ service-ները։

```c#
public UserAccounts(IParametersService parameterService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.parametersService = parameterService;
}
```

## Նկարագրման հատվածի ձևավորում

### Մուտքագրման դաշտերի(ռեկվիզիտների) ավելացում

Ավելացնել մուտքագրման դաշտերը որպես հատկություններ` սահմանելով հետևյալ կառուցվածքով՝
  -  get-ում վերադարձնել մուտքագրման դաշտի արժեքը՝ base դասի indexer-ին տալով դաշտի անունը և այդ արժեքը բերելով հատկության տիպի,
  -  set-ում base դասի indexer-ին տալ մուտքագրման դաշտի անունը  և վերագրել դաշտի արժեքը։

```c#
public string NAME
{
    get { return (string)this[nameof(this.NAME)]; }
    set { this[nameof(this.NAME)] = value; }
}

public string BRANCH
{
    get { return (string)this[nameof(this.BRANCH)]; }
    set { this[nameof(this.BRANCH)] = value; }
}
```

### Աղյուսակների(գրիդերի) ավելացում

- Սահմանել դաս աղյուսակի տողերի համար, որը պետք է պարտադիր ժառանգի `GridRow` դասից: Դասում ավելացնել սյուները որպես հատկություններ` սահմանելով հետևյալ կառուցվածքով՝
   - get-ում վերադարձնել սյան արժեքը՝ base դասի indexer-ին տալով սյան անունը և այդ արժեքը բերելով հատկության տիպի,
   - set-ում base դասի indexer-ին տալ սյան անվանումը և վերագրել սյան արժեքը։

```c#
 public class AccountingRow : GridRow
 {
     public string ACCTYPE
     {
         get { return (string)this[nameof(this.ACCTYPE)]; }
         set { this[nameof(this.ACCTYPE)] = value; }
     }

     public int CODE
     {
         get { return (int)this[nameof(this.CODE)]; }
         set { this[nameof(this.CODE)] = value; }
     }
...
 }
```

- Սահմանել Grid&lt;T&gt; տիպի հատկություն՝ որպես T փոխանցելով աղյուսակի տողերը նկարագրող դասը: Հատկությունում վերադարձնել base դասի Grids IReadOnlyDictionary&lt;string, IGrid&gt; տիպի հատկության աղյուսակի անունով անդամը՝ բերելով Grid&lt;T&gt; տիպի:

```c#
 public Grid<AccountingRow> Accountings
 {
     get
     {
         return (Grid<AccountingRow>)this.Grids[nameof(this.Accountings)];
     }
 }
```

###  Մեծ տեքստային դաշտերի(մեմոների) ավելացում

Ավելացնել մեմոները որպես հատկություններ` սահմանելով հետևյալ կառուցվածքով՝
  - get-ում վերադարձնել [GetMemo](document.md#getmemo) մեթոդի կանչը՝ փոխանցելով մեմոյի անունը,
  - set-ում կանչել [SetMemo](document.md#setmemo) մեթոդը՝ փոխանցելով մեմոյի անունը և արժեքը։

```c#
public string COMMENT
{
    get { return GetMemo(nameof(this.COMMENT)); }
    set { SetMemo(nameof(this.COMMENT), value); }
}
```

## Մեթոդներ

### Action

-  Փաստաթղթի գրանցման ժամանակ  հավելյալ ստուգումներ կատարելու,   լոգում, տվյալների բազայի աղյուսակներում փոխկապակցված գրանցումներ կատարելու, ինչ-որ պայմաններից կախված փաստաթղթի էլեմենտների(ռեկվիզիտ, մեմո, աղյուսակ) և հատկությունների արժեքները փոփոխելու համար անհրաժեշտ է override անել [Action](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Action.html) մեթոդը:

```c#
public override async Task Action(ActionEventArgs args)
{
    if (string.IsNullOrWhiteSpace(this.BRANCH))
    {
       this.BRANCH = await this.parametersService.DefaultBranch();
    }
}
```

### Folders

-  Փաստաթուղթը FOLDERS աղյուսակում գրանցելու համար անհրաժեշտ է override անել [Folders](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Folders.html) մեթոդը՝ ստեղծելով և store անելով `FolderElement` դասի օբյեկտ, որը հանդիսանում է 4x համակարգում նկարագրված [AsFoldElement](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/AsFoldElement.html) դասի համարժեքը։

```c#
public override Task Folders(FoldersEventArgs args)
{
    var folderElement = new FolderElement()
    {
        FolderId = "UserAccounts",
        Status = FolderStatus.Edit,
        Key = this.ISN.ToString(),
        Comment = this.Description.ArmenianCaption,
        EComment = this.Description.EnglishCaption,
        Spec = this.USERNAME.LeftAlign(20) + this.BRANCH.LeftAlign(50)
    };
    this.DocumentService.StoreInFolder(this, folderElement);
    return Task.CompletedTask;
}
```

### Validate

-  Դաշտերի արժեքների ստուգման անհրաժեշտության դեպքում override անել [Validate](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Validate.html) մեթոդը:

```c#
public override Task Validate(ValidateEventArgs args)
{
    if (this.Accounts.RowCount == 0)
    {
        throw new Exception("Օգտագործողին հաշիվներ կցված չեն".ToArmenianANSI());
    }
    return Task.CompletedTask;
}
```

### Delete

-  Եթե կա անհրաժեշտություն փաստաթղթի հեռացումից առաջ ստուգումներ կատարելու և կապակցված տվյալներ հեռացնելու, ապա անհրաժեշտ է override անել [Delete](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/Delete.html) մեթոդը:

```c#
public override async Task Delete(DeleteEventArgs args)
{
   bool isDeletionAllowed = await this.parametersService.GetBooleanValue("DELETEALIENDOCS");
   if (!isDeletionAllowed)
   {
      throw new Exception("Փաստաթուղթը հեռացնելու իրավասություն չունեք".ToArmenianANSI());
   }
}
```
