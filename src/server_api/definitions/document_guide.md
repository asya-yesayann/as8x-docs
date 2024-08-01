---
layout: page
title: "(Document) Փաստաթղթի նկարագրման ձեռնարկ"
tags: [Document]
---

## Բովանդակություն

* [Ներածություն](#ներածություն)
* [.as ֆայլի նկարագրություն](#as-ֆայլի-նկարագրություն)
* [CodeGen-ով C# ֆայլի ձևավորում](#codegen-ով-c-ֆայլի-ձևավորում)
* [Իրադարձությունների C# ֆայլի նկարագրություն](#իրադարձությունների-c-ֆայլի-նկարագրություն)
  * [Կոնստրուկտորի ձևավորում](#կոնստրուկտորի-ձևավորում)
  * [Մեթոդներ](#մեթոդներ)


## Ներածություն

8X-ում փաստաթղթի նկարագրության համար հարկավոր է ունենալ [DOCUMENT](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/doc.html) նկարագրություն `.as` ֆայլում, և իրականացնել ինտերֆեյսի հետ չաշխատող իրադարձությունները C# դասում (`.cs` ֆայլում)։

Փաստաթղթի նկարագրությունը կատարվում է 4X գործիքներով, և դրանում ավելացվում միայն մի քանի 8X-ին յուրահատուկ են հատկություն, ինչպիսին է `PROCESSINGMODE`-ը։  
Նկարագրությունը ներմուծվում է SysCon գործիքով։

C# դասը սովորաբար դրվում է երկու `.cs` ֆայլում։  
Առաջինը գեներացվում է [CodeGen](/src/server_api/CodeGen/CodeGen.md) գործիքով, և պարունակում է նկարագրության հատվածը։  
Երկրորդը ստեղծվում է ձեռքով և պարունակում է ոչ ինտերֆեյսային իրադարձությունների իրականացումը (Validate, Action, Folders...)։

Արդյունքում կունենանք 4 ֆայլ:
- *definition*.as
- *definition*.cs
- *definition*.CodeGen.tt
- *definition*.CodeGen.cs

Տե՛ս 4 ֆայլերի [օրինակը](/src/server_api/examples/document_definition.md):

## .as ֆայլի նկարագրություն

DOCUMENT-ի սահմանումը տես 4X-ի [համապատասխան](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Defs/doc.html) ձեռնարկի։  
Նկարագրության մեջ հարկավոր է ավելացնել միայն `PROCESSINGMODE` (կատարման ռեժիմ) հատկությունը։

Օրինակ՝
``` as4x
DOCUMENT {
  NAME = UsrAccs;
  CAPTION = "Օգտագործողի հաշիվներ";
  ECAPTION = "User's accounts";
  PROCESSINGMODE = 8; '#DocProcessingMode2

  PAGE { CAPTION = "Ընդհանուր"; ECAPTION = "General";
    REKVIZIT {NAME = USERNAME; CAPTION = "Օգտագործողի անուն"; ECAPTION="User's name";         TYPE = C(20); };
    REKVIZIT {NAME = BRANCH;   CAPTION = "Մասնաճյուղ";        ECAPTION="Registration branch"; TYPE = C(10); };

    GRID {NAME = Accounts; CAPTION = "Հաշիվներ"; ECAPTION = "Accounts"; WIDTH = 13000; HEIGHT = 3000;
      COLUMN {NAME = ACCTYPE; CAPTION = "Տիպ"; ECAPTION = "Type"; TYPE = C(10);  };
      COLUMN {NAME = CODE;    CAPTION = "Կոդ"; ECAPTION = "Code"; TYPE = NP(16); };
    };

    MEMO {NAME = COMMENT; CAPTION = "Մեկնաբանություն"; ECAPTION = "Comment"; WIDTH = 7000; HEIGHT = 2300; };
  };
}
```

## CodeGen-ով C# ֆայլի ձևավորում

Առաջին C# ֆայլը գեներացվում է [CodeGen](/src/server_api/CodeGen/CodeGen.md) գործիքով, և պարունակում է նկարագրության հատվածը։

Տե՛ս [օրինակում](/src/server_api/examples/document_definition.md) ձևավորված `UsrAccs.CodeGen.cs` ֆայլը:

- Հայտատարարված է դաս, որը ունի փաստաթղթի ներքին անվանումը պարունակող `Document` ատրիբուտը և ժառանգում է [Document](document.md) դասից։
  ```c#
  [Document("UsrAccs")]
  public class UsrAccs : Document
  ```

- Ավելացված են մուտքագրման դաշտերը որպես հատկություններ` ճիշտ տիպի բերումները արած։
  ```c#
  /// <summary>
  /// Օգտագործողի անուն
  /// </summary>
  public string USERNAME
  {
      get { return (string)this[nameof(this.USERNAME)]; }
      set { this[nameof(this.USERNAME)] = value; }
  }

  /// <summary>
  /// Մասնաճյուղ
  /// </summary>
  public string BRANCH
  {
      get { return (string)this[nameof(this.BRANCH)]; }
      set { this[nameof(this.BRANCH)] = value; }
  }
  ```

- Ավելացված է դաս աղյուսակի տողերի համար, որը պետք է պարտադիր ժառանգի `GridRow` դասից:
  Աղյուսակի սյուները դասում հատկություններ են` ճիշտ տիպի բերումները արած։
  ```c#
  public partial class AccountsRow : GridRow
  {
      /// <summary>
      /// Տիպ
      /// </summary>
      public string ACCTYPE
      {
          get { return (string)this[nameof(this.ACCTYPE)]; }
          set { this[nameof(this.ACCTYPE)] = value; }
      }

      /// <summary>
      /// Կոդ
      /// </summary>
      public decimal CODE
      {
          get { return (decimal)this[nameof(this.CODE)]; }
          set { this[nameof(this.CODE)] = value; }
      }
  }
  ```

- Ավելացված է աղյուսակը վերադարձնող հատկությունը ճիշտ տիպի բերված։
  ```c#
  /// <summary>
  /// Հաշիվներ
  /// </summary>
  public Grid<AccountsRow> Accounts
  {
      get
      {
          return (Grid<AccountsRow>)this.Grids[nameof(this.Accounts)];
      }
  }
  ```

- Ավելացված է Մեծ տեքստային դաշտը(մեմո) որպես հատկություն
  ```c#
  public string COMMENT
  {
      get { return GetMemo(nameof(this.COMMENT)); }
      set { SetMemo(nameof(this.COMMENT), value); }
  }
  ```

## Իրադարձությունների C# ֆայլի նկարագրություն

Երկրորդ C# ֆայլը ստեղծվում է ձեռքով և պարունակում է ոչ ինտերֆեյսային իրադարձությունների իրականացումը (Validate, Action, Folders...)։  
Այն պետք է իր մեջ ունենա սահմանված նախրորդ քայլում ձևավոևված դասը partial հատկանիշով։

``` c#
public partial class UsrAccs
```

Տե՛ս [օրինակում](/src/server_api/examples/document_definition.md) ձևավորված `UsrAccs.cs` ֆայլը:

### Կոնստրուկտորի ձևավորում

Հարկավոր է ավելացնել public կոնստրուկտոր՝ IServiceProvider տիպի պարտադիր պարամետրով, որը պիտի կանչի base Document-ի կոնստրուկտորը և փոխանցի IServiceProvider տիպի պարամետրը:

Կոնստուկտորում կարող է ստանալ հարկավոր սերվիսները [ինյեկցիայի](/src/project/injection.md) միջոցով։  
Մասնավորապես, օրինակում, ստանում է նաև պարամետրերի հետ աշխատելու `IParametersService` սերվիսը։

```c#
private readonly IParametersService parametersService;

public UserAccounts(IParametersService parameterService, IServiceProvider serviceProvider) : base(serviceProvider)
{
    this.parametersService = parameterService;
}
```

### Մեթոդներ

Փաստաթղթի մեջ հարկավոր է գերբեռնել (override) հարկավոր մեթոդները համապատասխան իրադարձությունները մշակելու համար։  
Տե՛ս [փաստաթղթի բոլոր իրադարձությունները](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/ScriptProcs/DocEvents.html) 4X ձեռնարկում։

### Validate

Դաշտերի արժեքների ստուգման անհրաժեշտության դեպքում override անել [Validate](/src/server_api/definitions/document.md#validate) մեթոդը:

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

### Action

Փաստաթղթի գրանցման ժամանակ հավելյալ ստուգումներ կատարելու, լոգում, տվյալների բազայի աղյուսակներում փոխկապակցված գրանցումներ կատարելու, ինչ-որ պայմաններից կախված փաստաթղթի էլեմենտների(ռեկվիզիտ, մեմո, աղյուսակ) և հատկությունների արժեքները փոփոխելու համար անհրաժեշտ է override անել [Action](/src/server_api/definitions/document.md#action) մեթոդը:

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

Փաստաթուղթը FOLDERS աղյուսակում գրանցելու համար անհրաժեշտ է override անել [Folders](/src/server_api/definitions/document.md#folders) մեթոդը՝ ստեղծելով և գրանցելով `FolderElement`, որը հանդիսանում է 4x համակարգում նկարագրված [AsFoldElement](https://armsoft.github.io/as4x-docs/HTM/ProgrGuide/Functions/AsFoldElement.html) դասի համարժեքը։

```c#
public override Task Folders(FoldersEventArgs args)
{
    var folderElement = new FolderElement()
    {
        FolderId = "UserAccounts",
        Status = FolderStatus.Edit,
        Key = this.USERNAME,
        Comment = this.Description.ArmenianCaption,
        EComment = this.Description.EnglishCaption,
        Spec = this.USERNAME.LeftAlign(20) + this.BRANCH.LeftAlign(50)
    };
    this.DocumentService.StoreInFolder(this, folderElement);
    return Task.CompletedTask;
}
```

### Delete

Եթե կա անհրաժեշտություն փաստաթղթի հեռացումից առաջ ստուգումներ կատարելու և կապակցված տվյալներ հեռացնելու, ապա անհրաժեշտ է override անել [Delete](/src/server_api/definitions/document.md#delete) մեթոդը:

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
