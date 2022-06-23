using Post = UI.Services.PostgreSQL;
using Lite = UI.Services.SQLite;

namespace UI.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            IP.Text = Post.DatabaseContext.Host;
            fileLocation.Text = Lite.DatabaseContext.DataSource;
            DB_Switch();
        }

        private void DB_Switch()
        {
            if (localDB.Checked)
            {
                fileLocation.Enabled = true;
                openLocal.Enabled = true;
                createLocal.Enabled = true;
                remoteSave.Enabled = false;
                IP.Enabled = false;
                UI.Models.SharedResources.IsPostgreSQL = false;
            }
            else
            {
                fileLocation.Enabled = false;
                openLocal.Enabled = false;
                createLocal.Enabled = false;
                remoteSave.Enabled = true;
                IP.Enabled = true;
                UI.Models.SharedResources.IsPostgreSQL = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Post.DatabaseContext.Host = this.IP.Text;
            try
            {
                var tmp = new Post.DatabaseContext().MainCats.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect IP and/or there is no DB on this IP");
                //MessageBox.Show(ex.Message);
                return;
            }
        }

        private void DB_CheckedChanged(object sender, EventArgs e)=>DB_Switch();

        private void Cancel_Click(object sender, EventArgs e)=>this.Close();

        private void openLocal_Click(object sender, EventArgs e)
        {
            var a = openFileDialog1.ShowDialog();
            if (a == DialogResult.Cancel)
                return;
            var str = openFileDialog1.FileName;
            Lite.DatabaseContext.DataSource = str;
            try
            {
                var tmp = new Lite.DatabaseContext().MainCats.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect database format. Try creating a new one");
                //MessageBox.Show(ex.Message);
                return;
            }
        }

        private void createLocal_Click(object sender, EventArgs e)
        {
            var a = saveFileDialog1.ShowDialog();
            if (a == DialogResult.Cancel)
                return;
            var str = saveFileDialog1.FileName;
            Lite.DatabaseContext.DataSource = str;
            var db = new Lite.DatabaseContext();
            db.Database.EnsureCreated();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (localSync.Checked || serverSync.Checked)
            {
                syncDB.Enabled = true;
                openLocal.Enabled = true;
                IP.Enabled = true;
            }
            else
            {
                syncDB.Enabled = false;
                DB_Switch();
            }
        }

        private void syncDB_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new List<bool> { localSync.Checked, serverSync.Checked });
            DatabaseSync(new Post.DatabaseContext(), new Lite.DatabaseContext(), localSync.Checked, serverSync.Checked);
            Cancel.Enabled = false;
        }

        private static void DatabaseSync(Post.DatabaseContext P, Lite.DatabaseContext L, bool P2L = false, bool L2P = false)
        {
            //Post2SQLite Sync
            if (P2L)
            {
                //Main category sync
                var sourceMain = P.MainCats.ToList();
                var destMain = L.MainCats;
                foreach (var T in sourceMain)
                {
                    Lite.MainCat C = new Lite.MainCat { Mid = T.Mid, Name = T.Name, Link = T.Link };
                    var F = destMain.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destMain.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Name = C.Link;
                    }
                }
                L.SaveChanges();

                //Subcategories sync
                var sourceSub = P.SubCats.ToList();
                var destSub = L.SubCats;
                foreach (var T in sourceSub)
                {
                    Lite.SubCat C = new Lite.SubCat { Sid = T.Sid, Title = T.Title, Link = T.Link, Pages = T.Pages, Pmid = T.Pmid };
                    var F = destSub.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destSub.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Pages = C.Pages;
                        F.Pmid = C.Pmid;
                        F.Title = C.Title;
                    }
                }
                L.SaveChanges();

                //Catalog items sync
                var sourceCat = P.CatalogItems;
                var destCat = L.CatalogItems;
                foreach (var T in sourceCat)
                {
                    var discount = BitConverter.GetBytes((bool)T.Isdiscount);
                    var availiable = BitConverter.GetBytes((bool)T.Isinstock);
                    Lite.CatalogItem C = new Lite.CatalogItem { Cid = T.Cid, Name = T.Name, Link = T.Link, Price = T.Price, Oldprice = T.Oldprice, Props = T.Props, Psid = T.Psid, Isdiscount = discount, Isinstock = availiable };
                    var F = destCat.FirstOrDefault(c => c.Cid == C.Cid);
                    if (F == null)
                        destCat.Add(C);
                    else
                    {
                        F.Name = C.Name;
                        F.Link = C.Link;
                        F.Price = C.Price;
                        F.Oldprice = C.Oldprice;
                        F.Props = C.Props;
                        F.Psid = C.Psid;
                        F.Isdiscount = C.Isdiscount;
                        F.Isinstock = C.Isinstock;
                    }
                }
                L.SaveChanges();
            }
            //Post2SQLite Sync
            if (L2P)
            {
                //Main category sync
                var sourceMain = L.MainCats;
                var destMain = P.MainCats;
                foreach (var T in sourceMain)
                {
                    Post.MainCat C = new Post.MainCat { Mid = Convert.ToInt32(T.Mid), Name = T.Name, Link = T.Link };
                    var F = destMain.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destMain.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Name = C.Link;
                    }
                }
                P.SaveChanges();

                //Subcategories sync
                var sourceSub = L.SubCats;
                var destSub = P.SubCats;
                foreach (var T in sourceSub)
                {
                    Post.SubCat C = new Post.SubCat { Sid = Convert.ToInt32(T.Sid), Title = T.Title, Link = T.Link, Pages = Convert.ToInt32(T.Pages), Pmid = Convert.ToInt32(T.Pmid) };
                    var F = destSub.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destSub.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Pages = C.Pages;
                        F.Pmid = C.Pmid;
                        F.Title = C.Title;
                    }
                }
                P.SaveChanges();

                //Catalog items sync
                var sourceCat = L.CatalogItems;
                var destCat = P.CatalogItems;
                foreach (var T in sourceCat)
                {
                    bool discount = false, availiable = false;

                    discount = BitConverter.ToBoolean(T.Isdiscount);
                    availiable = BitConverter.ToBoolean(T.Isinstock);
                    Post.CatalogItem C = new Post.CatalogItem { Cid = Convert.ToInt32(T.Cid), Name = T.Name, Link = T.Link, Price = Convert.ToInt32(T.Price), Oldprice = Convert.ToInt32(T.Oldprice), Props = T.Props, Psid = Convert.ToInt32(T.Psid), Isdiscount = discount, Isinstock = availiable };
                    var F = destCat.FirstOrDefault(c => c.Cid == C.Cid);
                    if (F == null)
                        destCat.Add(C);
                    else
                    {
                        F.Name = C.Name;
                        F.Link = C.Link;
                        F.Price = C.Price;
                        F.Oldprice = C.Oldprice;
                        F.Props = C.Props;
                        F.Psid = C.Psid;
                        F.Isdiscount = C.Isdiscount;
                        F.Isinstock = C.Isinstock;
                    }
                }
                P.SaveChanges();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<bool> bools = e.Argument as List<bool>;
            var L = new Lite.DatabaseContext();
            var P = new Post.DatabaseContext();
            double progress = 0;
            //Post2SQLite Sync
            if (bools[0])
            {
                //Main category sync
                var sourceMain = P.MainCats.ToList();
                var destMain = L.MainCats;
                foreach (var T in sourceMain)
                {
                    Lite.MainCat C = new Lite.MainCat { Mid = T.Mid, Name = T.Name, Link = T.Link };
                    var F = destMain.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destMain.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Name = C.Link;
                    }
                }
                L.SaveChanges();
                progress = 5;
                backgroundWorker1.ReportProgress(Convert.ToInt32(progress));

                //Subcategories sync
                var sourceSub = P.SubCats.ToList();
                var destSub = L.SubCats;
                foreach (var T in sourceSub)
                {
                    Lite.SubCat C = new Lite.SubCat { Sid = T.Sid, Title = T.Title, Link = T.Link, Pages = T.Pages, Pmid = T.Pmid };
                    var F = destSub.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destSub.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Pages = C.Pages;
                        F.Pmid = C.Pmid;
                        F.Title = C.Title;
                    }
                    progress += 30 / L.SubCats.Count();
                    if (progress >= 30)
                        progress = 30;
                    backgroundWorker1.ReportProgress(Convert.ToInt32(progress));
                }
                L.SaveChanges();

                //Catalog items sync
                var sourceCat = P.CatalogItems;
                var destCat = L.CatalogItems;
                foreach (var T in sourceCat)
                {
                    var discount = BitConverter.GetBytes((bool)T.Isdiscount);
                    var availiable = BitConverter.GetBytes((bool)T.Isinstock);
                    Lite.CatalogItem C = new Lite.CatalogItem { Cid = T.Cid, Name = T.Name, Link = T.Link, Price = T.Price, Oldprice = T.Oldprice, Props = T.Props, Psid = T.Psid, Isdiscount = discount, Isinstock = availiable };
                    var F = destCat.FirstOrDefault(c => c.Cid == C.Cid);
                    if (F == null)
                        destCat.Add(C);
                    else
                    {
                        F.Name = C.Name;
                        F.Link = C.Link;
                        F.Price = C.Price;
                        F.Oldprice = C.Oldprice;
                        F.Props = C.Props;
                        F.Psid = C.Psid;
                        F.Isdiscount = C.Isdiscount;
                        F.Isinstock = C.Isinstock;
                    }
                    progress += 70 / L.SubCats.Count();
                    if (progress >= 100)
                        progress = 100;
                    backgroundWorker1.ReportProgress(Convert.ToInt32(progress));
                }
                L.SaveChanges();
            }
            //Post2SQLite Sync
            if (bools[1])
            {
                //Main category sync
                var sourceMain = L.MainCats;
                var destMain = P.MainCats;
                foreach (var T in sourceMain)
                {
                    Post.MainCat C = new Post.MainCat { Mid = Convert.ToInt32(T.Mid), Name = T.Name, Link = T.Link };
                    var F = destMain.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destMain.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Name = C.Link;
                    }
                }
                P.SaveChanges();

                //Subcategories sync
                var sourceSub = L.SubCats;
                var destSub = P.SubCats;
                foreach (var T in sourceSub)
                {
                    Post.SubCat C = new Post.SubCat { Sid = Convert.ToInt32(T.Sid), Title = T.Title, Link = T.Link, Pages = Convert.ToInt32(T.Pages), Pmid = Convert.ToInt32(T.Pmid) };
                    var F = destSub.FirstOrDefault(c => c.Link == C.Link);
                    if (F == null)
                        destSub.Add(C);
                    else
                    {
                        F.Link = C.Link;
                        F.Pages = C.Pages;
                        F.Pmid = C.Pmid;
                        F.Title = C.Title;
                    }
                }
                P.SaveChanges();

                //Catalog items sync
                var sourceCat = L.CatalogItems;
                var destCat = P.CatalogItems;
                foreach (var T in sourceCat)
                {
                    bool discount = false, availiable = false;

                    discount = BitConverter.ToBoolean(T.Isdiscount);
                    availiable = BitConverter.ToBoolean(T.Isinstock);
                    Post.CatalogItem C = new Post.CatalogItem { Cid = Convert.ToInt32(T.Cid), Name = T.Name, Link = T.Link, Price = Convert.ToInt32(T.Price), Oldprice = Convert.ToInt32(T.Oldprice), Props = T.Props, Psid = Convert.ToInt32(T.Psid), Isdiscount = discount, Isinstock = availiable };
                    var F = destCat.FirstOrDefault(c => c.Cid == C.Cid);
                    if (F == null)
                        destCat.Add(C);
                    else
                    {
                        F.Name = C.Name;
                        F.Link = C.Link;
                        F.Price = C.Price;
                        F.Oldprice = C.Oldprice;
                        F.Props = C.Props;
                        F.Psid = C.Psid;
                        F.Isdiscount = C.Isdiscount;
                        F.Isinstock = C.Isinstock;
                    }
                }
                P.SaveChanges();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Cancel.Enabled = true;
        }
    }
}