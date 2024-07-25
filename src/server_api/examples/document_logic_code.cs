using System;
using System.Threading.Tasks;
using ArmSoft.AS8X.Common.Extensions;
using ArmSoft.AS8X.Core;
using ArmSoft.AS8X.Core.Document;
using ArmSoft.AS8X.Core.Folder;

namespace ArmSoft.AS8X.Bank.General.AccBal.DOCS
{
    public partial class UserAccounts : Document
    {
        private readonly IParametersService parametersService;

        public UserAccounts(IParametersService parameterService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.parametersService = parameterService;

        }

        public override Task Validate(ValidateEventArgs args)
        {
            if (this.Accounts.RowCount == 0)
            {
                throw new Exception("Օգտագործողին հաշիվներ կցված չեն".ToArmenianANSI());
            }
            return Task.CompletedTask;
        }

        public override async Task Action(ActionEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(this.BRANCH))
            {
                this.BRANCH = await this.parametersService.DefaultBranch();
            }
        }

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

        public override async Task Delete(DeleteEventArgs args)
        {
            bool isDeletionAllowed = await this.parametersService.GetBooleanValue("DELETEALIENDOCS");
            if (!isDeletionAllowed)
            {
                throw new Exception("Փաստաթուղթը հեռացնելու իրավասություն չունեք".ToArmenianANSI());
            }
        }
    }
}
