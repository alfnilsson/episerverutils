using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Templates.Alloy.Business.Settings;

namespace EPiServer.Templates.Alloy.Models.Blocks.Settings
{
[ContentType(DisplayName = "My Settings", GUID = "bc9d37bd-c725-4b8b-8a23-039710f476bf", Description = "", AvailableInEditMode = false)]
public class MySettingsBlock : BlockData, ISettingsBlock
{
    [Display(
        Name = "My Setting",
        GroupName = SystemTabNames.Content,
        Order = 1)]
    public virtual string MySetting { get; set; }
        
    [Display(
        Name = "My Setting with a Fallback",
        GroupName = SystemTabNames.Content,
        Order = 2)]
    public virtual string MySettingWithFallback {
        get
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            return this["MySettingWithFallback"] as string
                ?? contentLoader.Get<PageData>(ContentReference.StartPage).Name;
        }
        set { this["MySettingWithFallback"] = value; } }
}
}