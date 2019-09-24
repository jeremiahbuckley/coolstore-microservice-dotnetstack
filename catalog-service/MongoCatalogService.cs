using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CatalogService.Models;
using MongoDB.Driver;
// using MongoDB.Bson;

namespace CatalogService 
{
    public class MongoCatalogSvc : ICatalogSvc
    {

        // Logger log;

        private IMongoCollection<Product> productCollection;

        public IList<Product> GetProducts()
        {
            return productCollection.Find(book => true).ToList();
        }

        public void Add(Product product) {
            productCollection.InsertOne(product);
        }

        public void AddAll(IList<Product> products) {
            productCollection.InsertMany(products);
        }

        // @PostConstruct
        public MongoCatalogSvc() {
            // log.info("@PostConstruct is called...");

            // String dbName = System.getenv("DB_NAME");
            string dbName = "CatalogDB";
            if(string.IsNullOrWhiteSpace(dbName)) {
                // log.info("Could not get environment variable DB_NAME using the default value of 'CatalogDB'");
                dbName = "CatalogDB";
            }
            var mc = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase db = mc.GetDatabase(dbName);

            string collectionName = "products";
            productCollection = db.GetCollection<Product>(collectionName);

            // Drop the collection if it exists and then add default content
            db.DropCollection(collectionName);
            AddAll(DEFAULT_PRODUCT_LIST);

        }

        // @PreDestroy
        // protected void Destroy() {
        //     log.info("Closing MongoClient connection");
        //     if(mc!=null) {
        //         mc.close();
        //     }
        // }


        private static IList<Product> DEFAULT_PRODUCT_LIST = new List<Product>();
        static MongoCatalogSvc() {
            DEFAULT_PRODUCT_LIST.Add(new Product("329299", "Red Fedora", "Official Red Hat Fedora", 34.99));
            DEFAULT_PRODUCT_LIST.Add(new Product("329199", "Forge Laptop Sticker", "JBoss Community Forge Project Sticker", 8.50));
            DEFAULT_PRODUCT_LIST.Add(new Product("165613", "Solid Performance Polo", "Moisture-wicking, antimicrobial 100% polyester design wicks for life of garment. No-curl, rib-knit collar; special collar band maintains crisp fold; three-button placket with dyed-to-match buttons; hemmed sleeves; even bottom with side vents; Import. Embroidery. Red Pepper.", 17.80));
            DEFAULT_PRODUCT_LIST.Add(new Product("165614", "Ogio Caliber Polo", "Moisture-wicking 100% polyester. Rib-knit collar and cuffs; Ogio jacquard tape inside neck; bar-tacked three-button placket with Ogio dyed-to-match buttons; side vents; tagless; Ogio badge on left sleeve. Import. Embroidery. Black.", 28.75));
            DEFAULT_PRODUCT_LIST.Add(new Product("165954", "16 oz. Vortex Tumbler", "Double-wall insulated, BPA-free, acrylic cup. Push-on lid with thumb-slide closure; for hot and cold beverages. Holds 16 oz. Hand wash only. Imprint. Clear.", 6.00));
            DEFAULT_PRODUCT_LIST.Add(new Product("444434", "Pebble Smart Watch", "Smart glasses and smart watches are perhaps two of the most exciting developments in recent years. ", 24.00));
            DEFAULT_PRODUCT_LIST.Add(new Product("444435", "Oculus Rift", "The world of gaming has also undergone some very unique and compelling tech advances in recent years. Virtual reality, the concept of complete immersion into a digital universe through a special headset, has been the white whale of gaming and digital technology ever since Geekstakes Oculus Rift GiveawayNintendo marketed its Virtual Boy gaming system in 1995.Lytro", 106.00));
            DEFAULT_PRODUCT_LIST.Add(new Product("444436", "Lytro Camera", "Consumers who want to up their photography game are looking at newfangled cameras like the Lytro Field camera, designed to take photos with infinite focus, so you can decide later exactly where you want the focus of each image to be. ", 44.30));

        }

    }
}
