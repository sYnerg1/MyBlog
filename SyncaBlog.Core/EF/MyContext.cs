using SyncaBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncaBlog.Core.EF
{
    public class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        static MyContext()
        {
            Database.SetInitializer<MyContext>(new DbInitializer());
        }
        public MyContext(string EFDbContext)
            : base(EFDbContext)
        {
        }
        public MyContext()
            : base("EFDbContext")
        { }

    }
    public class DbInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext db)

        {
            Blog b1 = new Blog() { Name = "sYnerg1 Blog", Description = "My test blog for mu project." };
            Blog b2 = new Blog()
            {
                Name = "About Our World",
                Description = "This blog contains texts abot our world " +
                "and the most beatiful places"
            };
            Blog b3 = new Blog() { Name = "Chika Chika Blog", Description = "Пишу все, что меня интересует, Добро пожаловать!!!" };
            Blog b4 = new Blog() { Name = "Анатолий Германский", Description = "Персональный блог Анатолия Германского." };
            Blog b5 = new Blog() { Name = "Истории мира и остальное", Description = "Описание важных событий в мире, музыке и кино. Будет весело!" };



            Post p1 = new Post()
            {
                Title = "My First Post In This Blog",
                Text = "     Let me introduce myself. " +
                "My name is Ann. I am twenty. I am a student. I study at the university. I am a prospective economist. " +
                "I like this profession, that’s why I study with pleasure. My parents are not economists, but they support me in my choice." +
                " We are a friendly family and try to understand and support each other in any situation. Understanding and support is what " +
                "I need in friendship as well. Some of my friends study at the same university. After classes we usually gather to­gether," +
                " discuss our plans or problems and have some fun. We have a lot of hobbies.",
                ShortText = "Let me introduce myself..." +
                "My name is Ann. I am twenty. I am a student. I study at the university. I am a prospective economist. " +
                "I like this profession, that’s why I study with pleasure. My parents are not economists, but they support me in my choice.",
                CreationTime = DateTime.Now
            };


            Post p2 = new Post()
            {
                Title = "America, the beautiful: geographical position",
                Text = "     The main landmass of the United States lies in central North America. In the north it borders on Canada. In the south it borders on Mexico. " +
                "The United States is washed by the Atlantic Ocean in the east and the Pacific Ocean in the west. The two newest states, Alaska (united in 1959) and Hawaii (united in 1959)," +
                " are separated from the continental Unites States. Alaska borders on northwestern Canada. Hawaii lies in the central Pacific." +
                "The USA is very large and has many kinds of land. It stretches 2,575 kilometers from north to south and 4,500 kilometers from east to west. The deep-green mountain forests of the" +
                " northwest coast are filled with more than 250 centimeters of rain each year. At the other extreme, the deserts of the southwest receive less than 13 centimeters annually.",
                ShortText = "The main landmass of the United States lies in central North America. In the north it borders on Canada. In the south it borders on Mexico. " +
                "The United States is washed by the Atlantic Ocean in the east and the Pacific Ocean in the west...",
                CreationTime = DateTime.Now
            };

            Post p3 = new Post()
            {
                Title = "Art in Ukraine",
                Text = "      Ukrainian nation is very talented. Ukrainians have created many masterpieces in music, painting, cinema and theatre arts." +
                "Music is one of the oldest arts in Ukraine. Ukrainians are known as a musical people with a lot of folk-songs. Now there are 6 opera houses, 3 operettas and many song-and-dance groups." +
                " Ukrainian orchestras, choirs and performers often appear on tours in Europe, Asia and the USA. The pop music is rather developed in Ukraine. Pop singers like T. Povalii, I. Shynkaruk, S. Rotaru," +
                " and I. Bilyk are known in Ukraine and abroad." +
                "The oldest paintings in Ukraine are frescoes. Some of them are about a thousand years old. Famous frescoes of St. Sophia Cathedral in Kiev attract many tourists from Ukraine and abroad." +
                " Some Ukrainian painters are also famous all over the world. Among them is Ilia Repin (1844— 1930).",
                ShortText = "Ukrainian nation is very talented. Ukrainians have created many masterpieces in music, painting, cinema and theatre arts." +
                "Music is one of the oldest arts in Ukraine. Ukrainians are known as a musical people with a lot of folk-songs.",
                CreationTime = DateTime.Now
            };
            Post p4 = new Post()
            {
                Title = "Television",
                Text = "      Television has many advantages and disadvantages. First the advantages: it keeps us informed about the latest news. You don’t have to buy a newspaper to know about the current news or weather" +
                " forecast. Secondly, television provides entertainment in the home; you can watch a movie that you like without going to the cinema, or you can enjoy various music channels when you come back home tired." +
                "Besides this, it helps us to know more about the world, the people that live in it, and the cultures that they represent. All of these widen people’s outlook. On the other hand, television has been blamed for " +
                "the violent behaviour of some young people. The violent movies that are shown on TV affect teenagers badly. In addition, television encourages children to sit indoors, instead of taking exercise. ",
                ShortText = "Television has many advantages and disadvantages. First the advantages: it keeps us informed about the latest news. You don’t have to buy a newspaper to know about the current news or weather",
                CreationTime = DateTime.Now
            };
            Post p5 = new Post()
            {
                Title = "Тарас Шевченко",
                Text = "   Тара́с Григо́рьевич[14] Шевче́нко (укр. Тара́с Григо́рович Шевче́нко[14]; 25 февраля (9 марта) 1814, село Моринцы, Звенигородский уезд Киевской губернии, Российская империя (ныне Черкасская область, Украина) — " +
                "26 февраля (10 марта) 1861, Санкт-Петербург, Российская империя) — украинский поэт и мыслитель[15]. Известен также как художник, прозаик, этнограф и революционер-демократ[16 " +
                "Литературное наследие Шевченко, центральную роль в котором играет поэзия, в частности сборник «Кобзарь», считается основой современной украинской литературы и во многом литературного украинского языка. Деятель украинского национального движения, " +
                "член Кирилло-Мефодиевского братства " +
                "Бо́льшая часть прозы Шевченко (повести, дневник, многие письма), а также некоторые стихотворения написаны на русском языке, в связи с чем часть исследователей относит творчество Шевченко, помимо украинской, также и к русской литературе" +
                "В 1825 году, когда Шевченко шёл 12-й год, умер его отец. С этого времени начинается тяжёлая кочевая жизнь беспризорного ребёнка: сначала прислуживал у дьячка-учителя, затем по окрестным сёлам у дьячков-маляров («богомазов», то есть художников-иконописцев). " +
                "Одно время Шевченко пас овец, затем служил у местного священника погонычем. В школе дьячка-учителя Шевченко выучился грамоте, а у маляров познакомился с элементарными приёмами рисования. На шестнадцатом году жизни, в 1829 году, он попал в число прислуги нового " +
                "помещика П. В. Энгельгардта — сначала в роли поварёнка, затем слуги-«казачка». Страсть к живописи не покидала его",
                ShortText = "Тара́с Григо́рьевич[14] Шевче́нко (укр. Тара́с Григо́рович Шевче́нко[14]; 25 февраля (9 марта) 1814, село Моринцы, Звенигородский уезд Киевской губернии, Российская империя (ныне Черкасская область, Украина) — 26 февраля (10 марта) 1861, Санкт-Петербург, Российская империя) " +
                "— украинский поэт и мыслитель[15]. Известен также как художник, прозаик, этнограф и революционер-демократ",
                CreationTime = DateTime.Now
            };
            Post p6 = new Post()
            {
                Title = "Отели Египта",
                Text = "    В Египте представлены отели всех известных мировых цепочек. Правда, «сетевой префикс» перед названием гостиницы вовсе не гарантирует качественный сервис. Общий подход следующий: если не нужен совсем уж бюджетный тур, ничего ниже «четверки» брать не стоит. Приличные «трешки» в стране" +
                " есть, но их надо знать «в лицо»: непроверенные варианты лучше отбросить сразу. «Двушки» в Египте? Забудьте сразу и навсегда. Вместо этого всегда помните, что система «все включено» в разных отелях может различаться весьма радикально: уточняйте все детали" +
                "В Александрии отели в основном городские, в пригородах — типично «пляжные», с большой территорией и широким спектром услуг. Анимации в местных гостиницах почти нет, а если такое явление и встречается, то, увы, не на русском языке. Зато очень часто в отелях есть собственные ночные клубы и дискотеки" +
                "Многие крупные отели указывают цены в долларах и евро и спокойно принимают эту валюту. Также в ходу карты MasterCard, Visa, American Express и Diners Club, причем их сегодня принимают уже не только в гостиницах но и в ресторанах и некоторых магазинах. Проблем с обменом дорожных чеков также нет — в любом" +
                " банке их возьмут, но ковыряться с ними будут достаточно долго, плюс добавят комиссию в 1-4 %. Проще воспользоваться банкоматами, которые встречаются практически повсеместно в крупных городах. Комиссию за снятие банки берут каждый свою, лучше уточнить перед поездкой, как выгоднее пользоваться картой и снимать деньги. ",
                ShortText = "В Египте представлены отели всех известных мировых цепочек. Правда, «сетевой префикс» перед названием гостиницы вовсе не гарантирует качественный сервис. Общий подход следующий: если не нужен совсем уж бюджетный тур, ничего ниже «четверки» брать не стоит",
                CreationTime = DateTime.Now
            };
            Post p7 = new Post()
            {
                Title = "Били Айшлиш и Єминем на Оскаре 2020",
                Text = "     Сенсация церемонии Грэмми, ставшая самой молодой исполнительницей, получившей четыре главных статуэтки главной музыкальной премии мира, выступила на главной киносцене мира. Билли Айлиш исполнила песню Yesterday The Beatles. Ее песня сопровождала трибьют церемонии Оскар, во время которого вспомнили всех представителей киноиндустрии, которых мир потерял в течение 2019 и 2020 годов" +
                "Билли Айлиш можно смело назвать юным провокатором и новым законодателем моды. Певица не согласна носить традиционные платья для красной дорожки и выбирает винтажные костюмы известных мировых брендов. На церемонию Оскар она пришла в белом оверсайз костюме Chanel. Образ она дополнила множеством брендированных аксессуаров Chanel." +
                "Напомним, Билли Айлиш напишет саундтрек для 25-го фильма о Джеймсе Бонде Не время умирать. Она станет самым юным автором песни для фильма об агенте 007 в истории. Другим ярким сюрпризом на «Оскаре» оказалось выступление рэпера Эминема. Он привел гостей церемонии в восторг, исполнив известную песню Lose Yourself. Трек звучал в фильме «Восьмая миля», завоевавшем «Оскар» в 2003 году. Сам Эминем сыграл в картине главную роль" +
                "На сцене рэпер появился в середине мероприятия. Как и Айлиш, он был одет во все черное. В сдержанном образе артиста нашлись два акцента: его шею украсила массивная золотая цепь, а голову — стильная кепка.",
                ShortText = "Сенсация церемонии Грэмми, ставшая самой молодой исполнительницей, получившей четыре главных статуэтки главной музыкальной премии мира, выступила на главной киносцене мира.",
                CreationTime = DateTime.Now
            };

            Tag t1 = new Tag() { Name = "Other" };
            Tag t2 = new Tag() { Name = "World" };
            Tag t3 = new Tag() { Name = "Art" };
            Tag t4 = new Tag() { Name = "Programming" };
            Tag t5 = new Tag() { Name = "Music" };
            Tag t6 = new Tag() { Name = "Culture" };
            Tag t7 = new Tag() { Name = "Games" };
            Tag t8 = new Tag() { Name = "Hobby" };
            Tag t9 = new Tag() { Name = "Sea" };
            Tag t10 = new Tag() { Name = "News" };


            Comment c1 = new Comment() { Description = "Nice Post\n Bro" };
            Comment c2 = new Comment() { Description = "It's so good text" };
            Comment c3 = new Comment() { Description = "Nice story" };
            Comment c4 = new Comment()
            {
                Description = "Yeeeeaaaaahhhh!!!!!!!" +
                "So Cool!!"
            };
            //Add tag to Post
            p1.MyTag.Add(t1);

            p2.MyTag.Add(t1);
            p2.MyTag.Add(t2);

            p3.MyTag.AddRange(new List<Tag>() { t1, t3 });

            p4.MyTag.AddRange(new List<Tag>() { t1 });
            p5.MyTag.AddRange(new List<Tag>() { t3, t6 });
            p6.MyTag.AddRange(new List<Tag>() { t1, t8, t9 });
            p7.MyTag.AddRange(new List<Tag>() { t5, t10 });
            //Add post to blog
            b1.MyPost.AddRange(new List<Post>() { p1, p2 });
            b2.MyPost.AddRange(new List<Post>() { p3, p4 });
            b3.MyPost.AddRange(new List<Post>() { p5 });
            b4.MyPost.AddRange(new List<Post>() { p6 });
            b5.MyPost.AddRange(new List<Post>() { p7 });


            //add comments to post
            p1.MyComment.AddRange(new List<Comment>() { c1, c2, c3, c4 });

            //add to db
            db.Blogs.AddRange(new List<Blog>() { b1, b2, b3, b4, b5 });
            db.Posts.AddRange(new List<Post>() { p1, p2, p3, p4, p5, p6, p7 });
            db.Tags.AddRange(new List<Tag>() { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 });
            db.Comments.AddRange(new List<Comment>() { c1, c2, c3, c4 });
            //add users and role
            Role admin = new Role { Name = "admin" };
            Role moderator = new Role { Name = "moderator" };
            Role user = new Role { Name = "user" };

            db.Roles.Add(admin);
            db.Roles.Add(moderator);
            db.Roles.Add(user);
            db.Users.Add(new User
            {
                Email = "admin",
                Password = "123456",
                Role = admin,
                MyBlog = b1
            });
            db.Users.Add(new User
            {
                Email = "moderator",
                Password = "123456",
                Role = moderator,
                MyBlog = b2
            });
            db.Users.Add(new User
            {
                Email = "synerg1",
                Password = "123456",
                Role = user,
                MyBlog = b3
            });
            db.Users.Add(new User
            {
                Email = "chikachika",
                Password = "123456",
                Role = user,
                MyBlog = b4
            });
            db.Users.Add(new User
            {
                Email = "testuser",
                Password = "123456",
                Role = user,
                MyBlog = b5
            });


            base.Seed(db);
            db.SaveChanges();
        }
    }
}


