using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace watchbox
{
    public static class DB
    {
        public static string BaseDir => Application.StartupPath;

        public static string DataDir => Path.Combine(BaseDir, "Data");

        public static string DbPath => Path.Combine(DataDir, "watchbox.db");

        private static readonly string connectionString =
            $"Data Source={DbPath};Version=3;Pooling=True;Journal Mode=WAL;Busy Timeout=3000;";

        public static SQLiteConnection GetConnection()
            => new SQLiteConnection(connectionString);

        public static void EnsureDatabase()
        {
            Directory.CreateDirectory(DataDir);

            using var con = GetConnection();
            con.Open();

            using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
                pragma.ExecuteNonQuery();

            using var tx = con.BeginTransaction();

            using (var cmd = new SQLiteCommand(con) { Transaction = tx })
            {
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username  TEXT NOT NULL UNIQUE,
                        Password  TEXT NOT NULL,
                        CreatedAt TEXT DEFAULT CURRENT_TIMESTAMP
                    );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Lists (
                        Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId      INTEGER NOT NULL,
                        Name        TEXT NOT NULL,
                        Description TEXT,
                        IsPublic    INTEGER NOT NULL DEFAULT 0,
                        CreatedAt   TEXT,
                        FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE
                    );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Films (
                        Id              INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title           TEXT NOT NULL,
                        Year            INTEGER,
                        Genre           TEXT,
                        CoverPath       TEXT,
                        FilmDescription TEXT
                    );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_Films_Title_Year ON Films(Title, Year);";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS ListFilms (
                        Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                        ListId  INTEGER NOT NULL,
                        FilmId  INTEGER NOT NULL,
                        AddedAt TEXT,
                        UNIQUE(ListId, FilmId),
                        FOREIGN KEY(ListId) REFERENCES Lists(Id) ON DELETE CASCADE,
                        FOREIGN KEY(FilmId) REFERENCES Films(Id) ON DELETE CASCADE
                    );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS UserFilmStatus (
                        UserId    INTEGER NOT NULL,
                        FilmId    INTEGER NOT NULL,
                        Rating    REAL,
                        IsLiked   INTEGER DEFAULT 0,
                        WatchedAt TEXT,
                        PRIMARY KEY (UserId, FilmId),
                        FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE,
                        FOREIGN KEY(FilmId) REFERENCES Films(Id) ON DELETE CASCADE
                    );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS FilmNotes (
                        Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        FilmId    INTEGER NOT NULL,
                        UserId    INTEGER NOT NULL,
                        Note      TEXT,
                        CreatedAt TEXT,
                        UpdatedAt TEXT,
                        FOREIGN KEY(FilmId) REFERENCES Films(Id) ON DELETE CASCADE,
                        FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE
                    );";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS FilmComments (
                        Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        FilmId    INTEGER,
                        UserId    INTEGER,
                        Comment   TEXT,
                        CreatedAt TEXT,
                        FOREIGN KEY(FilmId) REFERENCES Films(Id) ON DELETE CASCADE,
                        FOREIGN KEY(UserId) REFERENCES Users(Id) ON DELETE CASCADE
                    );";
                cmd.ExecuteNonQuery();

                EnsureColumn(con, tx, "Films", "CoverPath", "TEXT");
                EnsureColumn(con, tx, "Films", "FilmDescription", "TEXT");

                EnsureColumn(con, tx, "Films", "Rating", "REAL");
                EnsureColumn(con, tx, "Films", "IsLiked", "INTEGER");
                EnsureColumn(con, tx, "Films", "WatchedAt", "TEXT");

                EnsureColumn(con, tx, "Users", "CreatedAt", "TEXT DEFAULT CURRENT_TIMESTAMP");
                EnsureColumn(con, tx, "Lists", "CreatedAt", "TEXT");
                EnsureColumn(con, tx, "ListFilms", "AddedAt", "TEXT");
                EnsureColumn(con, tx, "FilmNotes", "CreatedAt", "TEXT");
                EnsureColumn(con, tx, "FilmNotes", "UpdatedAt", "TEXT");
            }

            SeedFilmsIfEmpty(con, tx);

            tx.Commit();
        }

        private static void SeedFilmsIfEmpty(SQLiteConnection con, SQLiteTransaction tx)
        {
            long count;
            using (var c = new SQLiteCommand("SELECT COUNT(*) FROM Films;", con, tx))
                count = (long)c.ExecuteScalar();

            if (count > 0) return;

            var seedSql = @"
                INSERT OR IGNORE INTO Films (Title, Year, Genre, CoverPath, FilmDescription) VALUES
                ('Black Swan',2010,'Gerilim','black_swan.jpg','Bir balerinin mükemmellik takıntısı, gerçekle hayal arasındaki çizgiyi yok eder.'),
                ('Blade Runner 2049',2017,'Bilim Kurgu','blade_runner_2049.jpg','Yeni bir blade runner, insanlığın kaderini değiştirecek bir sırrın izini sürer.'),
                ('The Dark Knight',2008,'Aksiyon','dark_knight.jpg','Batman, Gotham’ı kaosa sürükleyen Joker’e karşı mücadele eder.'),
                ('Dune',2021,'Bilim Kurgu','dune.jpg','Çöl gezegeninde güç, kader ve kehanet; Paul Atreides’in yolculuğu başlar.'),
                ('Fight Club',1999,'Dram','fight_club.jpg','Tüketim toplumuna karşı bir başkaldırı: kimlik, şiddet ve sırlar.'),
                ('Forrest Gump',1994,'Dram','forrest_gump.jpg','Forrest’in saf kalbi, onu tarihin dönüm noktalarına sürükler.'),
                ('Gladiator',2000,'Aksiyon','gladiator.png','Bir generalin intikamı, arenalarda efsaneye dönüşür.'),
                ('The Godfather',1972,'Suç','godfather.jpg','Bir ailenin güç, sadakat ve bedellerle örülü mafya hikâyesi.'),
                ('Gone Girl',2014,'Gerilim','gone_girl.jpg','Bir kayboluş; evlilik ve yalanlar üzerinden karanlık bir oyun.'),
                ('The Green Mile',1999,'Dram','green_mile.jpg','İdam mahkûmu bir adam ve mucizevi bir güç: vicdanı sarsan bir hikâye.'),
                ('Her',2013,'Romantik','her.jpg','Yalnız bir adam, bir yapay zekâ ile beklenmedik bir bağ kurar.'),
                ('Inception',2010,'Bilim Kurgu','inception.jpg','Rüyalara sızan bir ekip, imkânsız bir fikir ekme görevine çıkar.'),
                ('Interstellar',2014,'Bilim Kurgu','interstellar.jpg','İnsanlığın geleceği için uzayın derinliklerinde zamanla yarış.'),
                ('Joker',2019,'Dram','joker.jpg','Toplumun dışına itilen bir adamın dönüşümü, şehri ateşe verir.'),
                ('La La Land',2016,'Romantik','la_la_land.png','Hayaller ve aşk; Los Angeles ışıkları altında zor seçimler.'),
                ('The Lord of the Rings: The Fellowship of the Ring',2001,'Macera','lotr1.jpg','Tek Yüzük’ü yok etmek için tehlikeli bir yolculuk başlar.'),
                ('The Matrix',1999,'Bilim Kurgu','matrix.jpg','Gerçek sandığın şey bir simülasyon olabilir; uyanış başlıyor.'),
                ('Oldboy',2003,'Gerilim','old_boy.jpg','Yıllarca hapsedilen bir adam, serbest kalınca intikamın izini sürer.'),
                ('Parasite',2019,'Dram','parasite.jpg','İki sınıfın kesişimi; zekice plan kontrolden çıkar.'),
                ('The Prestige',2006,'Gerilim','prestige.jpg','İki sihirbazın rekabeti, saplantıya dönüşür.'),
                ('Pulp Fiction',1994,'Suç','pulp_fiction.jpg','Birbirine bağlanan hikâyeler; suç ve kara mizah.'),
                ('Saving Private Ryan',1998,'Savaş','saving_private_ryan.jpg','Normandiya’dan sonra bir askeri kurtarmak için ölümcül görev.'),
                ('Se7en',1995,'Gerilim','se7en.jpg','Yedi ölümcül günahı izleyen bir katilin peşinde iki dedektif.'),
                ('The Shawshank Redemption',1994,'Dram','shawshank.jpg','Umut, dostluk ve özgürlük; duvarları aşar.'),
                ('The Silence of the Lambs',1991,'Gerilim','silence.jpg','Genç bir ajan, seri katili yakalamak için bir mahkûmdan yardım alır.'),
                ('The Social Network',2010,'Dram','social_network.jpg','Facebook’un doğuşu: başarı ve ihanet.'),
                ('Titanic',1997,'Romantik','titanic.jpg','Büyük felaketin gölgesinde imkânsız bir aşk.'),
                ('The Truman Show',1998,'Dram','truman_show.jpg','Hayatının bir şov olduğunu fark eden Truman gerçeğin peşine düşer.'),
                ('The Wolf of Wall Street',2013,'Dram','wall_street.png','Hız, para ve çöküş; borsanın karanlık yüzü.'),
                ('Whiplash',2014,'Dram','whiplash.jpg','Mükemmeliyet için sınırlar zorlanır: davulcu ve acımasız eğitmen.');
                ";
            using var cmd = new SQLiteCommand(seedSql, con, tx);
            cmd.ExecuteNonQuery();
        }

        private static void EnsureColumn(SQLiteConnection con, SQLiteTransaction tx, string table, string column, string typeSql)
        {
            using var check = new SQLiteCommand($"PRAGMA table_info({table});", con, tx);
            using var r = check.ExecuteReader();
            while (r.Read())
            {
                var colName = r["name"]?.ToString();
                if (string.Equals(colName, column, StringComparison.OrdinalIgnoreCase))
                    return;
            }

            using var alter = new SQLiteCommand(
                $"ALTER TABLE {table} ADD COLUMN {column} {typeSql};", con, tx);
            alter.ExecuteNonQuery();
        }
    }
}


