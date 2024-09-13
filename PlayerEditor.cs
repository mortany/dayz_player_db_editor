namespace DZ_Players;

public partial class PlayerEditor : UserControl
{
    private DzPlayersDb? DB;
    public PlayerEditor()
    {
        InitializeComponent();
    }
    public void LoadPlayerDB(string path)
    {
        DB = new DzPlayersDb(path);

        if(DB != null) 
        {
            playerCounter.Text = $"Записей: {DB.Players.Count}";
            LoadPlayersList();
        }
    }
    public void ReloadDB(string path)
    {
        ResetDB();
        ResetControls();
        LoadPlayerDB(path);
    }

    private void ResetDB() => DB = null;

    private void ResetControls()
    {
        playerCounter.Text = "Записей: 0";

        playersListBox.Items.Clear();
        playerInventory.Nodes.Clear();
        dupeInventory.Nodes.Clear();

        playerDbId.Clear();
        playerUID.Clear();
        playerChartype.Clear();
        playerStatus.Text = "Отсутствует";
    }
    private void LoadPlayersList()
    {
        playersListBox.BeginUpdate();

        foreach ( var player in DB.Players) 
            playersListBox.Items.Add(player);

        playersListBox.DisplayMember = "UID";
        playersListBox.SelectedIndex = 0;
        playersListBox.EndUpdate();
    }

    private void Click_Button_Action(object sender, EventArgs e)
    {
        if (DB == null)
            return;
        if (sender == searchPlayerButton)
            FindNextPlayer();
        else if (sender == searchDuplicatesButton)
            SearchDuplicates();
        else if(sender == clearDuplicatesListButton)
            dupeInventory.Nodes.Clear();

    }
    private void FindNextPlayer()
    {
        if (string.IsNullOrWhiteSpace(searchPlayer.Text)) 
            return;
        var uid = searchPlayer.Text;

        if (searchPlayer.Text.Length == 17) 
            uid = Utils.SteamIDToUID(uid);

        foreach (DzChar item in playersListBox.Items)
        {
            if (item.UID != uid)
                continue;
            playersListBox.SelectedItem = item;
            return;
        }
    }
    private void SearchDuplicates()
    {
        var allItemsList = new Dictionary<string, List<DzItem>>();
        var parentWithDupedItems = new Dictionary<string, List<DzItem>>();

        var playerNode = new TreeNode("Players");
        var itemsNode = new TreeNode("Items");

        foreach (var player in DB.Players)
        {
            if (player.Items == null || !player.Alive)
                continue;
            foreach (var item in player.Items)
            {
                if(!allItemsList.ContainsKey(item.PersistentGuid))
                    allItemsList.Add(item.PersistentGuid, new List<DzItem>());
                allItemsList[item.PersistentGuid].Add(item);
            }
        }

        foreach (var pairItem in allItemsList)
        {
            if (pairItem.Value.Count <= 1) 
                continue;
            var itemNode = new TreeNode(pairItem.Key);
            foreach(var item in pairItem.Value)
            {
                if (!parentWithDupedItems.ContainsKey(item.Parent))
                    parentWithDupedItems.Add(item.Parent, new List<DzItem>());

                parentWithDupedItems[item.Parent].Add(item);
                itemNode.Nodes.Add(ParseItem(item));
            }
            itemsNode.Nodes.Add(itemNode);
        }

        var sortDict = parentWithDupedItems
            .OrderByDescending(kvp => kvp.Value.Count)
            .ToList();

        dupeInventory.BeginUpdate();
        dupeInventory.Nodes.Clear();
           

        foreach (var pair in sortDict)
        {
            var player = new TreeNode($"Count: {pair.Value.Count} {pair.Key}");

            foreach (var item in pair.Value) 
                player.Nodes.Add(ParseItem(item));
            playerNode.Nodes.Add(player);
        }

        dupeInventory.Nodes.Add(playerNode);
        dupeInventory.Nodes.Add(itemsNode);

        dupeInventory.EndUpdate();
        
    }
    private void SelectNextPlayer(object sender, EventArgs e)
    {
        if (playersListBox.SelectedIndex == -1) 
            return;

        if (playersListBox.SelectedItem is not DzChar player)
            return;

        playerDbId.Text = player.ID.ToString();
        playerUID.Text = player.UID;
        playerChartype.Text = player.CharacterName;
        playerStatus.Text = player.Alive ? "Alive" : "Dead";

        ParseInventory(player);
    }
    private void ParseInventory(DzChar? player)
    {
        if(player?.Items == null)
            return;

        playerInventory.BeginUpdate();
        playerInventory.Nodes.Clear();

        foreach (var item in player.Items) 
            playerInventory.Nodes.Add(ParseItem(item));

        playerInventory.EndUpdate();
    }
    private static TreeNode ParseItem(DzItem item)
    {
        var itemNode = new TreeNode(item.Classname);
        itemNode.Tag = item;

        itemNode.Nodes.Add( new TreeNode($"Slot: {item.Slot}"));
        itemNode.Nodes.Add( new TreeNode($"PersistentID: {item.PersistentGuid}"));
        itemNode.Nodes.Add(new TreeNode($"ParentUID: {item.Parent}"));

        var cargo = new TreeNode("Cargo");
        var attachments = new TreeNode("Attachments");

        if (item.Childs == null) 
            return itemNode;
        foreach( var child in item.Childs )
        {
            var childNode = ParseItem(child);

            if( child.Slot == "cargo") 
                cargo.Nodes.Add( childNode );
            else
                attachments.Nodes.Add( childNode );
        }

        if( cargo.Nodes.Count > 0)
            itemNode.Nodes.Add(cargo);
        if( attachments.Nodes.Count > 0)
            itemNode.Nodes.Add(attachments);

        return itemNode;
    }
}
