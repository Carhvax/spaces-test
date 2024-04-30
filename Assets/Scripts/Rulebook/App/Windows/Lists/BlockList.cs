public class BlockList : ItemList<BlockItem> {

    protected override void OnListWasChanged() => Items.For((i, p) => p.ChangeIndex(i + 1));

}
