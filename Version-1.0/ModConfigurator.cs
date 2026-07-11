using Bindito.Core;

namespace Calloatti.SyncMods
{
  /// <summary>
  /// Handles systems that need to exist in multiple contexts (MainMenu AND Game).
  /// </summary>
  [Context("MainMenu")]
  [Context("Game")]
  public class GlobalConfigurator : IConfigurator
  {
    public void Configure(IContainerDefinition containerDefinition)
    {
      // Play dead if Sync Mods Pro is running
      if (!ModStarter.ShouldRun) return;

      // Wire up your localization tool
      LocHelper.Register(containerDefinition);
    }
  }

  /// <summary>
  /// Handles systems that strictly only belong on the Main Menu.
  /// </summary>
  [Context("MainMenu")]
  public class MainMenuConfigurator : Configurator
  {
    protected override void Configure()
    {
      // Play dead if Sync Mods Pro is running
      if (!ModStarter.ShouldRun) return;

      // Wire up the internal sync service
      Bind<SyncModsinternal>().AsSingleton();
    }
  }
}