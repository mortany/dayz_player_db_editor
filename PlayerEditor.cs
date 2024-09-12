using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;

namespace DZ_Players
{
    public partial class PlayerEditor : UserControl
    {
        private DZ_PlayersDB? DB;
        private SHA256 sha256_hash;
        public PlayerEditor()
        {
            sha256_hash = SHA256.Create();
            InitializeComponent();
        }
        public void LoadPlayerDB(string path)
        {
            DB = new DZ_PlayersDB(path);

            if(DB != null) 
            {
                playerCounter.Text = "Записей:" + DB.Players.Count;
                LoadPlayersList();
            }
        }
        public void ReloadDB(string path)
        {
            ResetDB();
            ResetControls();
            LoadPlayerDB(path);
        }
        public void ResetDB() { DB = null; }

        public void ResetControls()
        {
            playerCounter.Text = "Записей:0";

            playersListBox.Items.Clear();
            playerInventory.Nodes.Clear();
            dupeInventory.Nodes.Clear();

            playerUID.Clear();
            playerChartype.Clear();
            playerStatus.Text = "None";
        }
        private void LoadPlayersList()
        {
            playersListBox.BeginUpdate();

            foreach ( var player in DB.Players)
            {
                playersListBox.Items.Add(player);
            }

            playersListBox.DisplayMember = "UID";
            playersListBox.SelectedIndex = 0;
            playersListBox.EndUpdate();
        }
        private string ConvertSteam64ToUID(string steam64)
        {
            return System.Convert.ToBase64String(sha256_hash.ComputeHash(Encoding.ASCII.GetBytes(steam64))).Replace('/', '_').Replace('+', '-');
        }
        private void Click_Button_Action(object sender, EventArgs e)
        {
            if (DB != null)
            {
                if (sender == searchPlayerButton)
                    FindNextPlayer();
                else if (sender == searchDuplicatesButton)
                    SearchDuplicates();
                else if(sender == clearDuplicatesListButton)
                    dupeInventory.Nodes.Clear();
            }
            
        }
        private void FindNextPlayer()
        {
            if (searchPlayer.Text.Length > 0)
            {
                string uid = searchPlayer.Text;

                if (searchPlayer.Text.Length == 17)
                {
                    uid = ConvertSteam64ToUID(uid);
                }

                foreach (var item in playersListBox.Items)
                {
                    if (item.ToString() == uid)
                    {
                        playersListBox.SelectedItem = item;
                        return;
                    }

                }
            }
        }
        private void SearchDuplicates()
        {
            Dictionary<string,List<DZ_Item>> AllitemList = new Dictionary<string, List<DZ_Item>>();
            Dictionary<string,List<DZ_Item>> ParentWithDupedItems = new Dictionary<string, List<DZ_Item>>();

            TreeNode player_node = new TreeNode("Players");
            TreeNode items_node = new TreeNode("Items");

            foreach (var player in DB.Players)
            {
                if( player.Items != null && player.Alive)
                {
                    foreach (var item in player.Items)
                    {
                        if(!AllitemList.ContainsKey(item.GetN_ID()))
                            AllitemList.Add(item.GetN_ID(), new List<DZ_Item>());

                        AllitemList[item.GetN_ID()].Add(item);
                    }
                }
            }

            foreach (var pair_item in AllitemList)
            {
                if(pair_item.Value.Count > 1)
                {

                    TreeNode item_node = new TreeNode(pair_item.Key);

                    foreach(var item in pair_item.Value)
                    {
                        if (!ParentWithDupedItems.ContainsKey(item.Parent))
                            ParentWithDupedItems.Add(item.Parent, new List<DZ_Item>());

                        ParentWithDupedItems[item.Parent].Add(item);
                        item_node.Nodes.Add(ParseItem(item));
                    }

                    items_node.Nodes.Add(item_node);
                }
            }

            List<KeyValuePair<string, List<DZ_Item>>> sort_dict = ParentWithDupedItems.ToList();

            sort_dict.Sort(
            delegate (KeyValuePair<string, List<DZ_Item>> pair1,
            KeyValuePair<string, List<DZ_Item>> pair2)
            {
                return pair2.Value.Count.CompareTo(pair1.Value.Count);
            });

            dupeInventory.BeginUpdate();
            dupeInventory.Nodes.Clear();
           

            foreach (var pair in sort_dict)
            {
                TreeNode player = new TreeNode("Count: " + pair.Value.Count + " "+ pair.Key);

                foreach (var item in pair.Value)
                {
                    player.Nodes.Add(ParseItem(item));
                }

                player_node.Nodes.Add(player);
            }

            dupeInventory.Nodes.Add(player_node);
            dupeInventory.Nodes.Add(items_node);

            dupeInventory.EndUpdate();
        
        }
        private void SelectNextPlayer(object sender, EventArgs e)
        {
            if (playersListBox.SelectedIndex == -1) return;

            DZ_Char? player = playersListBox.SelectedItem as DZ_Char;

            if (player == null ) return;

            playerUID.Text = player.UID;
            playerChartype.Text = player.Character_name;

            if(player.Alive)
                playerStatus.Text = "Alive";
            else
                playerStatus.Text = "Dead";

            ParseInventory(player);
        }
        private void ParseInventory(DZ_Char? player)
        {
            if(player == null) return;
            if(player.Items == null) return;

            playerInventory.BeginUpdate();
            playerInventory.Nodes.Clear();

            foreach (var item in player.Items)
            {
                playerInventory.Nodes.Add(ParseItem(item));
            }

            playerInventory.EndUpdate();
        }
        private TreeNode ParseItem(DZ_Item item)
        {
             TreeNode itemNode = new TreeNode(item.Classname);
             itemNode.Tag = item;

             itemNode.Nodes.Add( new TreeNode("Slot: " + item.Slot));
             itemNode.Nodes.Add( new TreeNode("NetworkID: " + item.GetID()));

             TreeNode cargo = new TreeNode("Cargo");
             TreeNode attachments = new TreeNode("Attachments");

             if(item.Childs != null)
             {
                foreach( var child in item.Childs )
                {
                    TreeNode child_node = ParseItem(child);

                    if( child.Slot == "cargo") 
                        cargo.Nodes.Add( child_node );
                    else
                        attachments.Nodes.Add( child_node );
                }

                if( cargo.Nodes.Count > 0)
                    itemNode.Nodes.Add(cargo);

                if( attachments.Nodes.Count > 0)
                    itemNode.Nodes.Add(attachments);
             }

             return itemNode;
        }
    }
}
