USE [db-a25-raphael]; -- S'assure qu'on est sur la bonne DB
GO

-- =============================================
-- GÉNÉRATEUR DE 100 UTILISATEURS (CLIENTS)
-- =============================================

DECLARE @i INT = 1;
DECLARE @TotalUsers INT = 100;

DECLARE @PasswordHash NVARCHAR(MAX) = '$2a$10$7QJH6G8bF9Zp1YhZ1YhZeuF9Zp1YhZeuF9Zp1YhZeuF9Zp1YhZe'; 

WHILE @i <= @TotalUsers
BEGIN
    INSERT INTO dbo.Users (Id,Name, Email, PasswordHash, Role)
    VALUES (
        NEWID(), -- Génère un ID unique
        
        -- Nom d'utilisateur (ex: DevClient_1, DevClient_2...)
        'DevClient_' + CAST(@i AS NVARCHAR(10)), 
        
        -- Email (ex: client1@devshop.com...)
        'client' + CAST(@i AS NVARCHAR(10)) + '@devshop.com', 
        
        @PasswordHash, -- Le mot de passe crypté
        
        'User' -- Rôle (pas Admin, mais simple User)
    );

    SET @i = @i + 1;
END

-- =============================================
-- VÉRIFICATION
-- =============================================
PRINT '100 Utilisateurs générés avec succès !';
SELECT TOP 10 * FROM dbo.Users ORDER BY Name DESC; -- Affiche les 10 derniers
SELECT Role, COUNT(*) as Total FROM dbo.Users GROUP BY Role; -- Affiche le total par rôle