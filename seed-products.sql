-- =====================================================
-- DevShop - 100 Produits pour Développeurs
-- Base de données: db-a25-raphael
-- Serveur: sql-a25-raphael-22e153.database.windows.net
-- =====================================================
-- 1. D'abord on crée les tables (car c'est une nouvelle base vide)

-- Vérifier les tables existantes (exécuter d'abord pour confirmer)
-- SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';

-- =====================================================
-- CATÉGORIE: Claviers Mécaniques (25 produits)
-- =====================================================
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Keychron K2 Pro', N'Clavier mécanique 75% sans fil avec switches Gateron Brown, rétroéclairage RGB et corps en aluminium.', 149.99, N'Claviers Mécaniques', 10),
(NEWID(), N'Keychron Q1 V2', N'Clavier custom 75% en aluminium CNC avec gasket mount et switches hot-swappable.', 179.99, N'Claviers Mécaniques', 8),
(NEWID(), N'Keychron K8 Pro', N'Clavier TKL sans fil avec QMK/VIA, switches Gateron et batterie 4000mAh.', 109.99, N'Claviers Mécaniques', 15),
(NEWID(), N'Ducky One 3 SF', N'Clavier 65% avec switches Cherry MX, PBT keycaps et hot-swap PCB.', 139.99, N'Claviers Mécaniques', 12),
(NEWID(), N'NuPhy Air75 V2', N'Clavier low-profile sans fil ultra-fin avec switches Gateron et RGB.', 129.99, N'Claviers Mécaniques', 20),
(NEWID(), N'Leopold FC660M', N'Clavier compact 65% avec switches Cherry MX et construction premium.', 119.99, N'Claviers Mécaniques', 7),
(NEWID(), N'HHKB Professional Hybrid', N'Clavier Topre 60% légendaire avec connectivité Bluetooth.', 329.99, N'Claviers Mécaniques', 5),
(NEWID(), N'Varmilo VA87M', N'Clavier TKL avec switches Cherry MX et keycaps PBT dye-sub.', 159.99, N'Claviers Mécaniques', 9),
(NEWID(), N'GMMK Pro', N'Clavier 75% modulaire avec cadre en aluminium et gasket mount.', 169.99, N'Claviers Mécaniques', 11),
(NEWID(), N'Akko 3068B Plus', N'Clavier 65% sans fil avec switches Akko CS et triple connectivité.', 79.99, N'Claviers Mécaniques', 25),
(NEWID(), N'Royal Kludge RK84', N'Clavier 75% tri-mode avec hot-swap et rétroéclairage RGB.', 69.99, N'Claviers Mécaniques', 30),
(NEWID(), N'Anne Pro 2', N'Clavier 60% Bluetooth avec switches Gateron et tap layers.', 89.99, N'Claviers Mécaniques', 18),
(NEWID(), N'Epomaker TH80 Pro', N'Clavier 75% avec écran LCD, gasket mount et knob rotatif.', 99.99, N'Claviers Mécaniques', 14),
(NEWID(), N'Womier K87', N'Clavier TKL avec boîtier acrylique transparent et RGB éclatant.', 59.99, N'Claviers Mécaniques', 22),
(NEWID(), N'Drop CTRL', N'Clavier TKL hot-swap avec cadre en aluminium et QMK.', 199.99, N'Claviers Mécaniques', 6),
(NEWID(), N'Filco Majestouch 2', N'Clavier full-size japonais avec switches Cherry MX de qualité.', 149.99, N'Claviers Mécaniques', 8),
(NEWID(), N'Das Keyboard 4 Professional', N'Clavier full-size avec switches Cherry MX Blue et média controls.', 169.99, N'Claviers Mécaniques', 10),
(NEWID(), N'Corsair K70 RGB Pro', N'Clavier gaming full-size avec switches Cherry MX et repose-poignet.', 179.99, N'Claviers Mécaniques', 15),
(NEWID(), N'SteelSeries Apex Pro', N'Clavier avec switches OmniPoint ajustables et écran OLED.', 199.99, N'Claviers Mécaniques', 7),
(NEWID(), N'Razer BlackWidow V4', N'Clavier gaming avec switches Razer Green et commande dial.', 229.99, N'Claviers Mécaniques', 12),
(NEWID(), N'Logitech G Pro X', N'Clavier TKL avec switches hot-swap et Lightspeed sans fil.', 149.99, N'Claviers Mécaniques', 16),
(NEWID(), N'HyperX Alloy Origins', N'Clavier TKL compact avec switches HyperX Red et RGB.', 89.99, N'Claviers Mécaniques', 20),
(NEWID(), N'Kinesis Advantage360', N'Clavier ergonomique split avec disposition concave et tenting.', 449.99, N'Claviers Mécaniques', 3),
(NEWID(), N'ZSA Moonlander', N'Clavier split ortholinéaire avec thumb cluster et RGB.', 365.00, N'Claviers Mécaniques', 4),
(NEWID(), N'Ergodox EZ', N'Clavier split programmable avec tenting et repose-poignet.', 325.00, N'Claviers Mécaniques', 5);

-- =====================================================
-- CATÉGORIE: Écrans (20 produits)
-- =====================================================
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Dell UltraSharp U2723QE', N'Moniteur 27" 4K IPS Black avec USB-C 90W et calibration usine.', 799.99, N'Écrans', 8),
(NEWID(), N'LG 27GP950-B', N'Moniteur 27" 4K 144Hz Nano IPS avec HDMI 2.1 et G-Sync.', 899.99, N'Écrans', 6),
(NEWID(), N'Samsung Odyssey G7 32"', N'Moniteur gaming 32" 1440p 240Hz VA avec courbure 1000R.', 699.99, N'Écrans', 10),
(NEWID(), N'ASUS ProArt PA279CV', N'Moniteur 27" 4K IPS pour créateurs avec Calman Verified.', 549.99, N'Écrans', 7),
(NEWID(), N'BenQ PD2725U', N'Moniteur 27" 4K pour designers avec Thunderbolt 3 et KVM.', 899.99, N'Écrans', 5),
(NEWID(), N'LG 34WN80C-B', N'Moniteur ultrawide 34" 1440p IPS avec USB-C 60W.', 599.99, N'Écrans', 9),
(NEWID(), N'Dell S3422DWG', N'Moniteur gaming ultrawide 34" 1440p 144Hz VA curved.', 449.99, N'Écrans', 12),
(NEWID(), N'ASUS ROG Swift PG279QM', N'Moniteur 27" 1440p 240Hz IPS avec G-Sync Ultimate.', 849.99, N'Écrans', 4),
(NEWID(), N'ViewSonic VP2785-4K', N'Moniteur 27" 4K avec Adobe RGB 99% et USB-C.', 699.99, N'Écrans', 6),
(NEWID(), N'AOC CU34G2X', N'Moniteur ultrawide 34" 1440p 144Hz VA abordable.', 399.99, N'Écrans', 15),
(NEWID(), N'Gigabyte M28U', N'Moniteur 28" 4K 144Hz IPS avec HDMI 2.1 et KVM.', 649.99, N'Écrans', 8),
(NEWID(), N'Alienware AW3423DWF', N'Moniteur ultrawide 34" QD-OLED 165Hz gaming premium.', 1099.99, N'Écrans', 3),
(NEWID(), N'LG 27UL850-W', N'Moniteur 27" 4K IPS avec USB-C et HDR400.', 449.99, N'Écrans', 11),
(NEWID(), N'Philips 279P1', N'Moniteur 27" 4K IPS avec webcam intégrée et USB-C.', 549.99, N'Écrans', 7),
(NEWID(), N'HP Z27k G3', N'Moniteur 27" 4K IPS avec Thunderbolt 4 et hub USB.', 749.99, N'Écrans', 5),
(NEWID(), N'Lenovo ThinkVision P27u-20', N'Moniteur 27" 4K IPS professionnel avec USB-C 100W.', 699.99, N'Écrans', 6),
(NEWID(), N'EIZO FlexScan EV2795', N'Moniteur 27" 1440p IPS sans bordure avec daisy chain.', 849.99, N'Écrans', 4),
(NEWID(), N'Samsung Smart Monitor M8', N'Moniteur 32" 4K avec Smart TV intégré et webcam.', 699.99, N'Écrans', 9),
(NEWID(), N'Apple Studio Display', N'Moniteur 27" 5K Retina avec webcam 12MP et six haut-parleurs.', 1599.99, N'Écrans', 3),
(NEWID(), N'LG DualUp 28MQ780', N'Moniteur 28" ratio 16:18 pour productivité maximale.', 699.99, N'Écrans', 5);

-- =====================================================
-- CATÉGORIE: Chaises Ergonomiques (15 produits)
-- =====================================================
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Herman Miller Aeron', N'Chaise ergonomique iconique avec support PostureFit SL et mesh pellicule.', 1395.00, N'Chaises Ergonomiques', 5),
(NEWID(), N'Herman Miller Embody', N'Chaise gaming/travail avec technologie BackFit et Pixelated Support.', 1795.00, N'Chaises Ergonomiques', 3),
(NEWID(), N'Steelcase Leap V2', N'Chaise ergonomique avec LiveBack et support lombaire ajustable.', 1199.00, N'Chaises Ergonomiques', 6),
(NEWID(), N'Steelcase Gesture', N'Chaise conçue pour les postures multi-appareils modernes.', 1299.00, N'Chaises Ergonomiques', 4),
(NEWID(), N'Humanscale Freedom', N'Chaise auto-ajustable avec mécanisme de recline par le poids.', 1149.00, N'Chaises Ergonomiques', 5),
(NEWID(), N'Secretlab Titan Evo 2022', N'Chaise gaming premium avec support lombaire L-ADAPT et mousse froide.', 519.00, N'Chaises Ergonomiques', 15),
(NEWID(), N'Autonomous ErgoChair Pro', N'Chaise ergonomique avec support lombaire et têtière ajustables.', 499.00, N'Chaises Ergonomiques', 12),
(NEWID(), N'Branch Ergonomic Chair', N'Chaise de bureau ergonomique avec 7 points d''ajustement.', 349.00, N'Chaises Ergonomiques', 18),
(NEWID(), N'IKEA Markus', N'Chaise de bureau haute avec support lombaire intégré.', 229.00, N'Chaises Ergonomiques', 25),
(NEWID(), N'Haworth Fern', N'Chaise avec dossier Wave Suspension inspiré de la nature.', 1095.00, N'Chaises Ergonomiques', 4),
(NEWID(), N'Razer Iskur V2', N'Chaise gaming avec support lombaire adaptatif et coussin mémoire.', 599.00, N'Chaises Ergonomiques', 10),
(NEWID(), N'noblechairs HERO', N'Chaise gaming premium en similicuir avec support lombaire intégré.', 489.00, N'Chaises Ergonomiques', 8),
(NEWID(), N'Sidiz T80', N'Chaise ergonomique coréenne avec S-curve et mesh respirant.', 699.00, N'Chaises Ergonomiques', 6),
(NEWID(), N'HON Ignition 2.0', N'Chaise de bureau mesh avec support lombaire 4-way ajustable.', 449.00, N'Chaises Ergonomiques', 14),
(NEWID(), N'Uplift Pursuit', N'Chaise ergonomique mesh avec réglages multiples et appui-tête.', 599.00, N'Chaises Ergonomiques', 9);

-- =====================================================
-- CATÉGORIE: Accessoires Dev (40 produits)
-- =====================================================

-- Mugs et Boissons (6 produits)
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Mug "It works on my machine"', N'Mug céramique 350ml avec le message culte des développeurs.', 19.99, N'Accessoires', 50),
(NEWID(), N'Mug "Coffee to Code Converter"', N'Mug magique qui change de couleur avec la chaleur.', 24.99, N'Accessoires', 40),
(NEWID(), N'Mug "sudo give me coffee"', N'Mug Linux pour les admins sys et devops.', 18.99, N'Accessoires', 45),
(NEWID(), N'Mug "404 Sleep Not Found"', N'Mug pour les nuits de debugging intenses.', 17.99, N'Accessoires', 55),
(NEWID(), N'Thermos Code & Coffee', N'Thermos isolé 500ml avec design circuit imprimé.', 34.99, N'Accessoires', 30),
(NEWID(), N'Mug "git commit -m first coffee"', N'Mug pour les développeurs Git addicts.', 19.99, N'Accessoires', 42);

-- Hoodies et Vêtements (7 produits)
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Hoodie "Hello World"', N'Hoodie noir coton premium avec le premier programme légendaire.', 59.99, N'Accessoires', 25),
(NEWID(), N'Hoodie GitHub Octocat', N'Hoodie officiel GitHub avec logo Octocat brodé.', 69.99, N'Accessoires', 20),
(NEWID(), N'T-Shirt "There is no place like 127.0.0.1"', N'T-shirt geek avec référence localhost.', 29.99, N'Accessoires', 35),
(NEWID(), N'T-Shirt Stack Overflow', N'T-shirt pour ceux qui copient-collent avec fierté.', 27.99, N'Accessoires', 40),
(NEWID(), N'Hoodie "I am not a robot"', N'Hoodie avec captcha design pour les humains.', 54.99, N'Accessoires', 22),
(NEWID(), N'Chaussettes Binary Code', N'Chaussettes avec motif binaire 01010101.', 14.99, N'Accessoires', 60),
(NEWID(), N'Casquette vim vs emacs', N'Casquette réversible pour les deux camps.', 24.99, N'Accessoires', 30);

-- Audio (8 produits)
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Sony WH-1000XM5', N'Casque Bluetooth premium avec ANC leader du marché.', 399.99, N'Accessoires', 5),
(NEWID(), N'Apple AirPods Pro 2', N'Écouteurs TWS avec ANC adaptatif et audio spatial.', 329.99, N'Accessoires', 12),
(NEWID(), N'Bose QuietComfort Ultra', N'Casque ANC avec immersive audio et confort premium.', 429.99, N'Accessoires', 6),
(NEWID(), N'Audio-Technica ATH-M50x', N'Casque studio de référence pour le monitoring.', 149.99, N'Accessoires', 15),
(NEWID(), N'Beyerdynamic DT 770 Pro', N'Casque fermé 80 ohms pour le studio et le gaming.', 159.99, N'Accessoires', 10),
(NEWID(), N'Sennheiser HD 560S', N'Casque ouvert audiophile pour une écoute analytique.', 199.99, N'Accessoires', 8),
(NEWID(), N'Shure MV7', N'Microphone USB/XLR pour streaming et podcasting.', 249.99, N'Accessoires', 12),
(NEWID(), N'Blue Yeti X', N'Microphone USB avec LED meters et effets Blue VO!CE.', 169.99, N'Accessoires', 18);

-- Bureau et Organisation (8 produits)
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Desk Mat XXL Developer', N'Tapis de bureau 900x400mm avec raccourcis clavier imprimés.', 39.99, N'Accessoires', 35),
(NEWID(), N'Support Laptop Rain Design mStand', N'Support aluminium pour laptop avec cable management.', 49.99, N'Accessoires', 20),
(NEWID(), N'Bras Monitor Ergotron LX', N'Bras articulé premium pour moniteur jusqu''à 34 pouces.', 179.99, N'Accessoires', 15),
(NEWID(), N'USB Hub Caldigit TS4', N'Dock Thunderbolt 4 avec 18 ports et 98W charging.', 399.99, N'Accessoires', 7),
(NEWID(), N'Webcam Logitech Brio 4K', N'Webcam 4K HDR avec Windows Hello et cadrage auto.', 199.99, N'Accessoires', 14),
(NEWID(), N'Lampe BenQ ScreenBar', N'Lampe de bureau LED pour moniteur sans éblouissement.', 109.99, N'Accessoires', 22),
(NEWID(), N'Cable Management Kit', N'Kit complet avec gaines, clips et velcro pour câbles.', 29.99, N'Accessoires', 45),
(NEWID(), N'Repose-Poignet Glorious', N'Repose-poignet en mousse mémoire pour clavier TKL.', 24.99, N'Accessoires', 30);

-- Gadgets Tech (6 produits)
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Stream Deck MK.2', N'Contrôleur 15 touches LCD pour streaming et productivité.', 149.99, N'Accessoires', 16),
(NEWID(), N'Raspberry Pi 5 8GB Kit', N'Kit complet Pi 5 avec boîtier, alimentation et SD card.', 129.99, N'Accessoires', 20),
(NEWID(), N'Arduino Starter Kit', N'Kit débutant avec Arduino Uno et composants électroniques.', 89.99, N'Accessoires', 25),
(NEWID(), N'Flipper Zero', N'Multi-tool portable pour pentesting et hacking éthique.', 169.99, N'Accessoires', 8),
(NEWID(), N'YubiKey 5 NFC', N'Clé de sécurité hardware pour 2FA et passwordless.', 55.00, N'Accessoires', 40),
(NEWID(), N'Keychron Wooden Palm Rest', N'Repose-poignet en noyer pour claviers 75%.', 35.00, N'Accessoires', 28);

-- Stickers et Déco (5 produits)
INSERT INTO dbo.Products (Id, Name, Description, Price, Category, Stock) VALUES
(NEWID(), N'Pack Stickers Dev 50pcs', N'Stickers laptop avec logos langages et frameworks.', 12.99, N'Accessoires', 100),
(NEWID(), N'Poster "Clean Code" Rules', N'Poster A2 avec les principes du Clean Code.', 19.99, N'Accessoires', 35),
(NEWID(), N'Figurine Octocat GitHub', N'Figurine vinyle collector du logo GitHub.', 29.99, N'Accessoires', 25),
(NEWID(), N'Rubber Duck Debugging', N'Canard en caoutchouc officiel pour le debugging.', 9.99, N'Accessoires', 80),
(NEWID(), N'LED Neon "< / >"', N'Néon LED avec symbole de code pour décoration bureau.', 49.99, N'Accessoires', 15);

-- =====================================================
-- Vérification finale
-- =====================================================
SELECT COUNT(*) AS TotalProducts FROM dbo.Products;
SELECT Category, COUNT(*) AS Count FROM dbo.Products GROUP BY Category ORDER BY Count DESC;
