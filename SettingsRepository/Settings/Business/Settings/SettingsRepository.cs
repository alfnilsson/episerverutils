using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace EPiServer.Templates.Alloy.Business.Settings
{
public class SettingsRepository<T> where T : BlockData, ISettingsBlock
{
    #region [ Private Fields ]

    private readonly Lazy<IContentRepository> _contentRepository = new Lazy<IContentRepository>(() => ServiceLocator.Current.GetInstance<IContentRepository>());
    private readonly Lazy<BlockTypeRepository> _blockTypeRepository = new Lazy<BlockTypeRepository>(() => ServiceLocator.Current.GetInstance<BlockTypeRepository>());

    private BlockTypeRepository BlockTypeRepository { get { return _blockTypeRepository.Value; } }
    private IContentRepository ContentRepository { get { return _contentRepository.Value; } }

    #endregion

    protected virtual ContentReference ParentFolder
    {
        get
        {
            return GetOrCreate<ContentFolder>(ContentReference.SiteBlockFolder, "[Settings]");
        }
    }

    protected virtual string DefaultBlockName
    {
        get
        {
            var blockType = BlockTypeRepository.Load<T>();
            return blockType.DisplayName;
        }
    }

    public T Instance
    {
        get
        {
            return GetOrCreateSettingsBlock();
        }
    }

    protected virtual T GetOrCreateSettingsBlock()
    {
        ContentReference contentLink = GetOrCreate<T>(ParentFolder, DefaultBlockName);

        return ContentRepository.Get<T>(contentLink);
    }

    private ContentReference GetOrCreate<TContentType>(ContentReference parentLink, string name) where TContentType : IContentData
    {
        ContentReference contentLink;
        var child = ContentRepository.GetChildren<TContentType>(parentLink, LanguageSelector.AutoDetect(true)).FirstOrDefault(x => ((IContent)x).Name == name);
        if (child == null)
        {
            var clone = ContentRepository.GetDefault<TContentType>(parentLink);
            var content = ((IContent)clone);
            content.Name = name;
            contentLink = ContentRepository.Save(content, SaveAction.Publish, AccessLevel.NoAccess);
        }
        else
        {
            contentLink = ((IContent)child).ContentLink;
        }

        return contentLink;
    }
}
}