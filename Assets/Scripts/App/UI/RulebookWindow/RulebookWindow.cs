using NaughtyAttributes;

public class RulebookWindow : Window
{
    private GuidedPanelsContainer Container => GuidedPanelsContainer.Instance;

    public TPanel Change<TPanel>() where TPanel : GuidedPanel => Container.Change<TPanel>();

    protected override void OnWindowShow()
    {
        Container.Change<RuleListPanel>().Init();
    }

    [Button]
    private void OpenPicker() => Container.Change<RuleResponsePicker>();

    [Button]
    private void ReturnBack() => Container.Back();
}
