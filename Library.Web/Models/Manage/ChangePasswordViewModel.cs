﻿namespace Library.Web.Models.Manage
{
    using Resources.Models.Manage;
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(ChangePasswordViewModelResx))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "ErrorNewPassword", MinimumLength = 6, ErrorMessageResourceType = typeof(ChangePasswordViewModelResx))]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(ChangePasswordViewModelResx))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(ChangePasswordViewModelResx))]
        [Compare("NewPassword", ErrorMessageResourceName = "ErrorConfirmNewPassword", ErrorMessageResourceType = typeof(ChangePasswordViewModelResx))]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}