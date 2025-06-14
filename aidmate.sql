
CREATE DATABASE AidMateDB;
GO
USE AidMateDB;
GO


-- Create EmergencyContacts Table


CREATE TABLE EmergencyContacts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    City NVARCHAR(100),
    ServiceType NVARCHAR(50),  -- Police, Fire Brigade, Rescue, etc.
    PhoneNumber NVARCHAR(50),
    Location NVARCHAR(255),
    Availability NVARCHAR(50), -- 24/7 or working hours
    Website NVARCHAR(255),
    Email NVARCHAR(255),
    SpecialServices NVARCHAR(255), -- Any special services like Cybercrime, Rescue, etc.
    Notes NVARCHAR(255)  -- Additional Notes like Important Tips
);

-- Create Categories Table (stores emergency categories like Burns, CPR, etc.)
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

-- Create Guides Table (stores the first aid guides for each category with Video File Path)
CREATE TABLE Guides (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT,
    Title NVARCHAR(255),
    Instructions TEXT,
    VideoFilePath NVARCHAR(255),  -- To store the path for the offline video file
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Create Bookmarks Table (optional, stores user bookmarks for quick access)
CREATE TABLE Bookmarks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT FOREIGN KEY REFERENCES Users(Id),--dropped
    CategoryName NVARCHAR(100),
    Timestamp DATETIME DEFAULT GETDATE()
);
ALTER TABLE Bookmarks
ADD UserEmail NVARCHAR(255);--added




ALTER TABLE Bookmarks
DROP COLUMN UserId;
ALTER TABLE Bookmarks
DROP CONSTRAINT FK__Bookmarks__UserI__5FB337D6;

Drop Table Bookmarks
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(255)  -- Store hashed passwords ideally
);
CREATE TABLE FirstAidKit (
    Id INT PRIMARY KEY IDENTITY,
    UserEmail VARCHAR(100),
    ItemName VARCHAR(100),
    Quantity VARCHAR(50),
    Status VARCHAR(50)
);





DELETE FROM Categories
WHERE Name = 'Bleeding'
AND Id = (SELECT Id FROM Categories WHERE Name = 'Bleeding');





-- Insert Categories
INSERT INTO Categories (Name) VALUES ('Burns');
INSERT INTO Categories (Name) VALUES ('CPR');
INSERT INTO Categories (Name) VALUES ('Fractures');
INSERT INTO Categories (Name) VALUES ('Choking');
INSERT INTO Categories (Name) VALUES ('Nosebleed');--
INSERT INTO Categories (Name) VALUES ('Heart Attack');--
INSERT INTO Categories (Name) VALUES ('Seizure');
INSERT INTO Categories (Name) VALUES ('Allergic Reaction');
INSERT INTO Categories (Name) VALUES ('Bleeding');
INSERT INTO Categories (Name) VALUES ('Fainting');
INSERT INTO Categories (Name) VALUES ('Poisoning');
INSERT INTO Categories (Name) VALUES ('Electric Shock');

-- =============== BURNS ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Burns'), 
    'Comprehensive Burn Treatment Protocol',
    '1. BURN CLASSIFICATION:' + CHAR(13) + CHAR(10) +
    '   • 1st Degree: Red, painful (sunburn)' + CHAR(13) + CHAR(10) +
    '   • 2nd Degree: Blisters, severe pain' + CHAR(13) + CHAR(10) +
    '   • 3rd Degree: White/black, no pain (nerve damage)' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. IMMEDIATE TREATMENT:' + CHAR(13) + CHAR(10) +
    '   • Thermal Burns:' + CHAR(13) + CHAR(10) +
    '     - Cool with 15-25°C water for 20 mins' + CHAR(13) + CHAR(10) +
    '     - Remove jewelry/clothing (unless fused)' + CHAR(13) + CHAR(10) +
    '   • Chemical Burns:' + CHAR(13) + CHAR(10) +
    '     - Flush continuously for 30+ mins' + CHAR(13) + CHAR(10) +
    '     - Brush off dry chemicals first' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. WOUND CARE:' + CHAR(13) + CHAR(10) +
    '   • Cover with sterile, non-adherent dressing' + CHAR(13) + CHAR(10) +
    '   • Apply antibiotic ointment for minor burns' + CHAR(13) + CHAR(10) +
    '   • Do NOT use cotton wool or fluffy materials' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. EMERGENCY SIGNS:' + CHAR(13) + CHAR(10) +
    '   • Burns >3 inches (7.5cm) diameter' + CHAR(13) + CHAR(10) +
    '   • Face/hands/genitals affected' + CHAR(13) + CHAR(10) +
    '   • Difficulty breathing after smoke inhalation',
    'C:\Users\User\Desktop\AidMateVideos\burns.mp4'
);

-- =============== CPR ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'CPR'), 
    '2023 CPR Protocol (AHA Guidelines)',
    '1. SCENE ASSESSMENT:' + CHAR(13) + CHAR(10) +
    '   • Check for safety (fire, wires, etc.)' + CHAR(13) + CHAR(10) +
    '   • Wear gloves/mask if available' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. PATIENT ASSESSMENT:' + CHAR(13) + CHAR(10) +
    '   • Tap-shout-tap: "Are you okay?"' + CHAR(13) + CHAR(10) +
    '   • Check breathing (scan chest 5-10 sec)' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. COMPRESSION TECHNIQUE:' + CHAR(13) + CHAR(10) +
    '   • Hand Position: Lower half of sternum' + CHAR(13) + CHAR(10) +
    '   • Depth: 2.4" (6cm) for adults' + CHAR(13) + CHAR(10) +
    '   • Rate: 100-120/min (match "Stayin'' Alive" rhythm)' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. RESCUE BREATHS:' + CHAR(13) + CHAR(10) +
    '   • Head-tilt chin-lift maneuver' + CHAR(13) + CHAR(10) +
    '   • 2 breaths (1 sec each), watch chest rise' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. AED OPERATION:' + CHAR(13) + CHAR(10) +
    '   • Power on and follow voice prompts' + CHAR(13) + CHAR(10) +
    '   • Continue CPR during AED analysis',
    'C:\Users\User\Desktop\AidMateVideos\cpr.mp4'
);

-- =============== FRACTURES ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Fractures'), 
    'Fracture Management: Splinting & Immobilization',
    '1. FRACTURE IDENTIFICATION:' + CHAR(13) + CHAR(10) +
    '   • Deformity or unnatural angle' + CHAR(13) + CHAR(10) +
    '   • Crepitus (grinding sound)' + CHAR(13) + CHAR(10) +
    '   • Inability to bear weight' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. SPLINTING TECHNIQUES:' + CHAR(13) + CHAR(10) +
    '   • Upper Limb:' + CHAR(13) + CHAR(10) +
    '     - Use triangular bandage for sling' + CHAR(13) + CHAR(10) +
    '     - Secure arm to torso' + CHAR(13) + CHAR(10) +
    '   • Lower Limb:' + CHAR(13) + CHAR(10) +
    '     - Splint with boards/rolled magazines' + CHAR(13) + CHAR(10) +
    '     - Bind injured leg to uninjured leg' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. OPEN FRACTURE CARE:' + CHAR(13) + CHAR(10) +
    '   • Cover wound with sterile dressing' + CHAR(13) + CHAR(10) +
    '   • Do NOT push protruding bones back' + CHAR(13) + CHAR(10) +
    '   • Control bleeding with direct pressure' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. EMERGENCY TRANSPORT:' + CHAR(13) + CHAR(10) +
    '   • Call ambulance for:' + CHAR(13) + CHAR(10) +
    '     - Pelvic fractures' + CHAR(13) + CHAR(10) +
    '     - Suspected spinal injury' + CHAR(13) + CHAR(10) +
    '     - Loss of distal pulse',
    'C:\Users\User\Desktop\AidMateVideos\fracture.mp4'
);

-- =============== CHOKING ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Choking'), 
    'Choking Response: Heimlich Maneuver Protocol',
    '1. ASSESSMENT:' + CHAR(13) + CHAR(10) +
    '   • Mild Obstruction:' + CHAR(13) + CHAR(10) +
    '     - Can cough/speak' + CHAR(13) + CHAR(10) +
    '     - Encourage continued coughing' + CHAR(13) + CHAR(10) +
    '   • Severe Obstruction:' + CHAR(13) + CHAR(10) +
    '     - Universal choking sign' + CHAR(13) + CHAR(10) +
    '     - Weak/no cough' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. HEIMLICH MANEUVER:' + CHAR(13) + CHAR(10) +
    '   • Standing Position:' + CHAR(13) + CHAR(10) +
    '     1. Stand behind victim' + CHAR(13) + CHAR(10) +
    '     2. Position fist above navel' + CHAR(13) + CHAR(10) +
    '     3. Quick upward thrusts' + CHAR(13) + CHAR(10) +
    '   • Special Cases:' + CHAR(13) + CHAR(10) +
    '     - Pregnant: Chest thrusts' + CHAR(13) + CHAR(10) +
    '     - Infants: Back blows + chest thrusts' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. UNCONSCIOUS VICTIM:' + CHAR(13) + CHAR(10) +
    '   • Begin CPR starting with compressions' + CHAR(13) + CHAR(10) +
    '   • Check mouth for object before breaths' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. POST-RESCUE CARE:' + CHAR(13) + CHAR(10) +
    '   • Medical evaluation required' + CHAR(13) + CHAR(10) +
    '   • Monitor for aspiration pneumonia',
    'C:\Users\User\Desktop\AidMateVideos\choking.mp4'
);

-- =============== SEIZURE ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Seizure'), 
    'Seizure First Aid: Dos and Donts',
    '1. SEIZURE PHASES:' + CHAR(13) + CHAR(10) +
    '   • Pre-Ictal (Aura):' + CHAR(13) + CHAR(10) +
    '     - Strange smells/tastes' + CHAR(13) + CHAR(10) +
    '     - Deja vu feeling' + CHAR(13) + CHAR(10) +
    '   • Ictal (Active Seizure):' + CHAR(13) + CHAR(10) +
    '     - Tonic-clonic movements' + CHAR(13) + CHAR(10) +
    '     - Loss of consciousness' + CHAR(13) + CHAR(10) +
    '   • Post-Ictal:' + CHAR(13) + CHAR(10) +
    '     - Confusion, fatigue' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. FIRST AID STEPS:' + CHAR(13) + CHAR(10) +
    '   • Time the seizure' + CHAR(13) + CHAR(10) +
    '   • Cushion head with soft material' + CHAR(13) + CHAR(10) +
    '   • Turn to recovery position post-seizure' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. EMERGENCY SIGNS:' + CHAR(13) + CHAR(10) +
    '   • Seizure >5 minutes' + CHAR(13) + CHAR(10) +
    '   • Repeated seizures without regaining consciousness' + CHAR(13) + CHAR(10) +
    '   • Difficulty breathing after seizure' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. DOCUMENTATION:' + CHAR(13) + CHAR(10) +
    '   • Duration of seizure' + CHAR(13) + CHAR(10) +
    '   • Body parts involved' + CHAR(13) + CHAR(10) +
    '   • Triggers observed',
    'C:\Users\User\Desktop\AidMateVideos\seizure.mp4'
);

-- =============== ALLERGIC REACTION ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Allergic Reaction'), 
    'Anaphylaxis Emergency Management',
    '1. RECOGNITION:' + CHAR(13) + CHAR(10) +
    '   • Skin: Hives, swelling (especially lips/face)' + CHAR(13) + CHAR(10) +
    '   • Respiratory: Wheezing, stridor' + CHAR(13) + CHAR(10) +
    '   • Cardiovascular: Dizziness, low BP' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. EPINEPHRINE ADMINISTRATION:' + CHAR(13) + CHAR(10) +
    '   • Use EpiPen®/Auvi-Q®:' + CHAR(13) + CHAR(10) +
    '     1. Remove safety cap' + CHAR(13) + CHAR(10) +
    '     2. Press firmly against outer thigh' + CHAR(13) + CHAR(10) +
    '     3. Hold for 3 seconds' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. POSITIONING:' + CHAR(13) + CHAR(10) +
    '   • Breathing difficulty: Sitting position' + CHAR(13) + CHAR(10) +
    '   • Shock: Lie flat with legs elevated' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. SECONDARY MEDICATIONS:' + CHAR(13) + CHAR(10) +
    '   • Antihistamines (diphenhydramine)' + CHAR(13) + CHAR(10) +
    '   • Corticosteroids (prednisone)' + CHAR(13) + CHAR(10) +
    '   • Bronchodilators if wheezing' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. FOLLOW-UP:' + CHAR(13) + CHAR(10) +
    '   • Hospital observation for 4-6 hours' + CHAR(13) + CHAR(10) +
    '   • Allergy testing recommended',
    'C:\Users\User\Desktop\AidMateVideos\allergy.mp4'
);

-- =============== BLEEDING ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Bleeding'), 
    'Hemorrhage Control: Pressure & Tourniquet Use',
    '1. MINOR BLEEDING:' + CHAR(13) + CHAR(10) +
    '   • Clean with saline/clean water' + CHAR(13) + CHAR(10) +
    '   • Apply direct pressure for 10 mins' + CHAR(13) + CHAR(10) +
    '   • Use adhesive bandage or Steri-Strips™' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. SEVERE BLEEDING:' + CHAR(13) + CHAR(10) +
    '   • Apply direct pressure with clean cloth' + CHAR(13) + CHAR(10) +
    '   • Add more layers if blood soaks through' + CHAR(13) + CHAR(10) +
    '   • Elevate injured limb above heart' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. TOURNIQUET USE:' + CHAR(13) + CHAR(10) +
    '   • Indications: Arterial spurting or amputation' + CHAR(13) + CHAR(10) +
    '   • Placement: 2-3 inches above wound' + CHAR(13) + CHAR(10) +
    '   • Tighten until bleeding stops' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. WOUND PACKING:' + CHAR(13) + CHAR(10) +
    '   • For deep wounds: Pack with hemostatic gauze' + CHAR(13) + CHAR(10) +
    '   • Apply pressure over packing' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. SHOCK MANAGEMENT:' + CHAR(13) + CHAR(10) +
    '   • Lay flat, elevate legs' + CHAR(13) + CHAR(10) +
    '   • Keep warm with blanket' + CHAR(13) + CHAR(10) +
    '   • Monitor consciousness',
    'C:\Users\User\Desktop\AidMateVideos\bleed.mp4'
);

-- =============== FAINTING ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Fainting'), 
    'Syncope Management & Prevention',
    '1. IMMEDIATE CARE:' + CHAR(13) + CHAR(10) +
    '   • Lay flat on back' + CHAR(13) + CHAR(10) +
    '   • Elevate legs 12 inches' + CHAR(13) + CHAR(10) +
    '   • Loosen tight clothing' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. RECOVERY POSITION:' + CHAR(13) + CHAR(10) +
    '   • If vomiting occurs, turn to side' + CHAR(13) + CHAR(10) +
    '   • Maintain airway' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. GRADUAL RECOVERY:' + CHAR(13) + CHAR(10) +
    '   • Sit up slowly after 15-20 mins' + CHAR(13) + CHAR(10) +
    '   • Offer fluids (water/juice)' + CHAR(13) + CHAR(10) +
    '   • Avoid sudden standing' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. RED FLAGS:' + CHAR(13) + CHAR(10) +
    '   • No recovery after 2 mins' + CHAR(13) + CHAR(10) +
    '   • Chest pain/palpitations before episode' + CHAR(13) + CHAR(10) +
    '   • Head injury from fall' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. PREVENTION:' + CHAR(13) + CHAR(10) +
    '   • Increase salt/water intake if prone' + CHAR(13) + CHAR(10) +
    '   • Learn warning signs (nausea, tunnel vision)' + CHAR(13) + CHAR(10) +
    '   • Counter-pressure maneuvers when prodromal',
    'C:\Users\User\Desktop\AidMateVideos\fainting.mp4'
);

-- =============== POISONING ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Poisoning'), 
    'Poison Exposure: First Response Protocol',
    '1. TOXIN IDENTIFICATION:' + CHAR(13) + CHAR(10) +
    '   • Save container/package' + CHAR(13) + CHAR(10) +
    '   • Note time of exposure' + CHAR(13) + CHAR(10) +
    '   • Estimate amount ingested' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. INGESTED POISONS:' + CHAR(13) + CHAR(10) +
    '   • Do NOT induce vomiting' + CHAR(13) + CHAR(10) +
    '   • Activated charcoal if advised by poison control' + CHAR(13) + CHAR(10) +
    '   • Milk/water only for specific caustics' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. INHALED POISONS:' + CHAR(13) + CHAR(10) +
    '   • Move to fresh air immediately' + CHAR(13) + CHAR(10) +
    '   • Administer oxygen if available' + CHAR(13) + CHAR(10) +
    '   • Monitor for respiratory distress' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. SKIN EXPOSURE:' + CHAR(13) + CHAR(10) +
    '   • Remove contaminated clothing' + CHAR(13) + CHAR(10) +
    '   • Rinse with water for 15-20 mins' + CHAR(13) + CHAR(10) +
    '   • Avoid spreading chemical during removal' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. EYE EXPOSURE:' + CHAR(13) + CHAR(10) +
    '   • Rinse from inner to outer corner' + CHAR(13) + CHAR(10) +
    '   • Hold eyelid open during irrigation' + CHAR(13) + CHAR(10) +
    '   • Continue rinsing during transport',
    'C:\Users\User\Desktop\AidMateVideos\poisoning.mp4'
);

-- =============== ELECTRIC SHOCK ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Electric Shock'), 
    'Electrical Injury: Emergency Protocol',
    '1. SCENE SAFETY:' + CHAR(13) + CHAR(10) +
    '   • Turn off power at source' + CHAR(13) + CHAR(10) +
    '   • Use non-conductive tool (wood/fiberglass)' + CHAR(13) + CHAR(10) +
    '   • High-voltage (>1000V): Stay 20+ feet away' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. PRIMARY SURVEY:' + CHAR(13) + CHAR(10) +
    '   • Check ABCs (Airway-Breathing-Circulation)' + CHAR(13) + CHAR(10) +
    '   • Assume spinal injury' + CHAR(13) + CHAR(10) +
    '   • Begin CPR if pulseless' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. BURN MANAGEMENT:' + CHAR(13) + CHAR(10) +
    '   • Look for entry/exit wounds' + CHAR(13) + CHAR(10) +
    '   • Cover with dry sterile dressings' + CHAR(13) + CHAR(10) +
    '   • Do NOT cool with water' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. HIDDEN INJURIES:' + CHAR(13) + CHAR(10) +
    '   • Cardiac monitoring required' + CHAR(13) + CHAR(10) +
    '   • Rhabdomyolysis risk (dark urine)' + CHAR(13) + CHAR(10) +
    '   • Compartment syndrome monitoring' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. DOCUMENTATION:' + CHAR(13) + CHAR(10) +
    '   • Voltage/current type if known' + CHAR(13) + CHAR(10) +
    '   • Duration of contact' + CHAR(13) + CHAR(10) +
    '   • Path of current through body',
    'C:\Users\User\Desktop\AidMateVideos\electricshock.mp4'
);

-- =============== NOSEBLEED ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Nosebleed'), 
    'Nosebleed First Aid: Complete Guide',
    '1. IMMEDIATE ACTION:' + CHAR(13) + CHAR(10) +
    '   • Sit upright and lean slightly forward' + CHAR(13) + CHAR(10) +
    '   • Pinch soft part of nose (below bony bridge)' + CHAR(13) + CHAR(10) +
    '   • Maintain pressure for 10-15 minutes' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. COLD COMPRESS:' + CHAR(13) + CHAR(10) +
    '   • Apply ice pack wrapped in cloth' + CHAR(13) + CHAR(10) +
    '   • Place on bridge of nose' + CHAR(13) + CHAR(10) +
    '   • Alternate 10 minutes on/5 minutes off' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. DO NOT:' + CHAR(13) + CHAR(10) +
    '   • Tilt head backward' + CHAR(13) + CHAR(10) +
    '   • Pack nose with tissue' + CHAR(13) + CHAR(10) +
    '   • Blow nose for several hours after' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. WHEN TO SEEK MEDICAL HELP:' + CHAR(13) + CHAR(10) +
    '   • Bleeding lasts >20 minutes' + CHAR(13) + CHAR(10) +
    '   • Caused by head injury' + CHAR(13) + CHAR(10) +
    '   • Taking blood thinners' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. PREVENTION TIPS:' + CHAR(13) + CHAR(10) +
    '   • Use humidifier in dry climates' + CHAR(13) + CHAR(10) +
    '   • Apply petroleum jelly to nostrils' + CHAR(13) + CHAR(10) +
    '   • Avoid nose picking',
    'C:\Users\User\Desktop\AidMateVideos\nosebleed.mp4'
);

-- =============== HEART ATTACK ===============
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Heart Attack'), 
    'Heart Attack Emergency Response',
    '1. RECOGNIZE SYMPTOMS:' + CHAR(13) + CHAR(10) +
    '   • Chest pressure/discomfort (lasts >15 min)' + CHAR(13) + CHAR(10) +
    '   • Pain radiating to arm/jaw/back' + CHAR(13) + CHAR(10) +
    '   • Cold sweat, nausea, dizziness' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '2. IMMEDIATE ACTION:' + CHAR(13) + CHAR(10) +
    '   • Call emergency services (1122) immediately' + CHAR(13) + CHAR(10) +
    '   • Chew 325mg aspirin (if not allergic)' + CHAR(13) + CHAR(10) +
    '   • Rest in comfortable position' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '3. COMFORT MEASURES:' + CHAR(13) + CHAR(10) +
    '   • Loosen tight clothing' + CHAR(13) + CHAR(10) +
    '   • Keep calm and still' + CHAR(13) + CHAR(10) +
    '   • Do NOT allow to walk' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '4. IF UNCONSCIOUS:' + CHAR(13) + CHAR(10) +
    '   • Check breathing and pulse' + CHAR(13) + CHAR(10) +
    '   • Begin CPR if no pulse' + CHAR(13) + CHAR(10) +
    '   • Use AED if available' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10) +
    '5. IMPORTANT NOTES:' + CHAR(13) + CHAR(10) +
    '   • Women may have atypical symptoms' + CHAR(13) + CHAR(10) +
    '   • Diabetics may have "silent" heart attacks' + CHAR(13) + CHAR(10) +
    '   • Every minute matters - act fast',
    'C:\Users\User\Desktop\AidMateVideos\heartattack.mp4'
);







-- For Burns

-- Karachi
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Karachi', 'Police', '021-99214000', 'Saddar, Karachi', '24/7', 'www.karachi-police.gov.pk', 'police@karachi.gov.pk', 'Cybercrime, Anti-Terrorism, Women''s Cell', 'In case of an accident or emergency, stay calm and give clear information about the situation and your location.'),
('Karachi', 'Fire Brigade', '102', 'Korangi, Karachi', '24/7', 'www.karachi-firebrigade.gov.pk', 'fire@karachi.gov.pk', 'Firefighting', 'Never use water on electrical fires, use a fire extinguisher. Evacuate the area immediately in case of fire; do not use elevators.'),
('Karachi', 'Rescue', '1122', 'Gulshan-e-Iqbal, Karachi', '24/7', 'www.rescue1122.gov.pk', 'rescue@karachi.gov.pk', 'First aid for burns, fractures, trauma, and other injuries', 'If you or someone is injured, stay still and avoid movement to prevent further injuries.');

-- Lahore
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Lahore', 'Police', '042-99211111', 'Shahdara, Lahore', '24/7', 'www.lahore-police.gov.pk', 'police@lahore.gov.pk', 'Anti-Crime Unit, Women''s Cell', 'If you see suspicious activity, report it immediately to ensure safety.'),
('Lahore', 'Fire Brigade', '16', 'Near Liberty Market, Lahore', '24/7', 'www.lahore-firebrigade.gov.pk', 'fire@lahore.gov.pk', 'Firefighting', 'Always check smoke detectors; if you smell gas, do not use open flames.'),
('Lahore', 'Rescue', '1122', 'Gulberg, Lahore', '24/7', 'www.rescue1122.gov.pk', 'rescue@lahore.gov.pk', 'First aid for burns, fractures, and trauma', 'If you''re in a crowd during a disaster, stay close to your family and call for help immediately.');

-- Islamabad
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Islamabad', 'Police', '051-9259065', 'Blue Area, Islamabad', '24/7', 'www.islamabad-police.gov.pk', 'police@islamabad.gov.pk', 'Cybercrime, Child Protection', 'Always call the police immediately when you witness criminal activity.'),
('Islamabad', 'Fire Brigade', '16', 'Sector G-7, Islamabad', '24/7', 'www.islamabad-firebrigade.gov.pk', 'fire@islamabad.gov.pk', 'Firefighting', 'Keep a fire extinguisher in your kitchen and near electrical appliances.'),
('Islamabad', 'Rescue', '1122', 'F-6, Islamabad', '24/7', 'www.rescue1122.gov.pk', 'rescue@islamabad.gov.pk', 'First aid for burns, fractures, trauma, and more', 'Avoid moving someone who is seriously injured unless it''s necessary.');

-- Faisalabad
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Faisalabad', 'Police', '041-9200000', 'Civil Lines, Faisalabad', '24/7', 'www.faisalabad-police.gov.pk', 'police@faisalabad.gov.pk', 'Anti-Terrorism, Crime Investigation', 'Contact the police immediately if you encounter any suspicious activity.'),
('Faisalabad', 'Fire Brigade', '16', 'Madina Town, Faisalabad', '24/7', 'www.faisalabad-firebrigade.gov.pk', 'fire@faisalabad.gov.pk', 'Firefighting', 'In case of a fire, evacuate the building and do not use elevators.'),
('Faisalabad', 'Rescue', '1122', 'Sargodha Road, Faisalabad', '24/7', 'www.rescue1122.gov.pk', 'rescue@faisalabad.gov.pk', 'First aid for trauma, burns, and fractures', 'Ensure you stay calm during emergencies and follow the instructions of emergency responders.');

-- Multan
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Multan', 'Police', '061-9200222', 'Bosan Road, Multan', '24/7', 'www.multan-police.gov.pk', 'police@multan.gov.pk', 'Anti-Drug Unit, Investigation', 'Report any suspicious activities immediately to the police.'),
('Multan', 'Fire Brigade', '16', 'Shujabad Road, Multan', '24/7', 'www.multan-firebrigade.gov.pk', 'fire@multan.gov.pk', 'Firefighting', 'Always have a fire escape plan and ensure your family knows the route.'),
('Multan', 'Rescue', '1122', 'Cantt Area, Multan', '24/7', 'www.rescue1122.gov.pk', 'rescue@multan.gov.pk', 'First aid for burns, fractures, trauma', 'Always call for help immediately after an accident.');

-- Quetta
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Quetta', 'Police', '081-9200000', 'Brewery Road, Quetta', '24/7', 'www.quetta-police.gov.pk', 'police@quetta.gov.pk', 'Anti-Crime, Women''s Protection', 'Do not hesitate to contact the police in case of emergency.'),
('Quetta', 'Fire Brigade', '16', 'Jinnah Road, Quetta', '24/7', 'www.quetta-firebrigade.gov.pk', 'fire@quetta.gov.pk', 'Firefighting', 'Evacuate immediately in case of fire and avoid using elevators.'),
('Quetta', 'Rescue', '1122', 'Civil Lines, Quetta', '24/7', 'www.rescue1122.gov.pk', 'rescue@quetta.gov.pk', 'First aid for injuries, burns, and trauma', 'Avoid panic and stay away from dangerous areas in case of a disaster.');

-- Rawalpindi
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Rawalpindi', 'Police', '051-9271122', 'Saddar, Rawalpindi', '24/7', 'www.rawalpindi-police.gov.pk', 'police@rawalpindi.gov.pk', 'Cybercrime, Crime Prevention', 'If you are in danger, stay calm and provide the location.'),
('Rawalpindi', 'Fire Brigade', '16', 'Murree Road, Rawalpindi', '24/7', 'www.rawalpindi-firebrigade.gov.pk', 'fire@rawalpindi.gov.pk', 'Firefighting', 'Keep fire exits clear and know the evacuation routes.'),
('Rawalpindi', 'Rescue', '1122', 'Raja Bazaar, Rawalpindi', '24/7', 'www.rescue1122.gov.pk', 'rescue@rawalpindi.gov.pk', 'First aid for burns, injuries, and other emergency medical issues', 'Stay away from fire hazards and call for help immediately.');

-- Peshawar
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Peshawar', 'Police', '091-9212121', 'Saddar, Peshawar', '24/7', 'www.peshawar-police.gov.pk', 'police@peshawar.gov.pk', 'Anti-Terrorism, Crime Prevention', 'In case of emergency, provide clear and accurate information to the police.'),
('Peshawar', 'Fire Brigade', '16', 'University Road, Peshawar', '24/7', 'www.peshawar-firebrigade.gov.pk', 'fire@peshawar.gov.pk', 'Firefighting', 'Never use water on electrical fires, use fire extinguishers or call for help immediately.'),
('Peshawar', 'Rescue', '1122', 'Khyber Bazaar, Peshawar', '24/7', 'www.rescue1122.gov.pk', 'rescue@peshawar.gov.pk', 'First aid for burns, fractures, and trauma', 'Stay calm and follow the instructions given by the emergency responders.');

-- Gujranwala
INSERT INTO EmergencyContacts (City, ServiceType, PhoneNumber, Location, Availability, Website, Email, SpecialServices, Notes)
VALUES 
('Gujranwala', 'Police', '055-9200000', 'GT Road, Gujranwala', '24/7', 'www.gujranwala-police.gov.pk', 'police@gujranwala.gov.pk', 'Crime Prevention, Traffic Control', 'Always provide clear information to the police during emergencies.'),
('Gujranwala', 'Fire Brigade', '16', 'Alipur, Gujranwala', '24/7', 'www.gujranwala-firebrigade.gov.pk', 'fire@gujranwala.gov.pk', 'Firefighting', 'If you see smoke or smell gas, leave the area immediately and call the fire brigade.'),
('Gujranwala', 'Rescue', '1122', 'Model Town, Gujranwala', '24/7', 'www.rescue1122.gov.pk', 'rescue@gujranwala.gov.pk', 'First aid for injuries, burns, trauma, and more', 'Always stay calm and wait for professional help.');




select * from Categories
select * from Guides
select* from users
select * from bookmarks
select* from FirstAidKit
DELETE FROM Categories;
Delete from guides
DBCC CHECKIDENT ('Categories', RESEED, 0);
use AidMateDB;


INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Burns'), 
    'Burns Treatment',
    '1. Remove the person from the source of the burn.' + CHAR(13) + CHAR(10) +
    '2. Cool the burn under cool running water for at least 10–15 minutes.' + CHAR(13) + CHAR(10) +
    '3. Remove any clothing or jewelry near the burned area (unless stuck to the skin).' + CHAR(13) + CHAR(10) +
    '4. Cover the burn with a sterile, non-stick dressing or clean cloth.' + CHAR(13) + CHAR(10) +
    '5. Do not apply ice, butter, or ointments.' + CHAR(13) + CHAR(10) +
    '6. Monitor for signs of shock.',
    'C:\Users\User\Desktop\AidMateVideos\burns.mp4'
);

-- For CPR
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'CPR'), 
    'CPR Guidelines',
    '1. Check for responsiveness and breathing.' + CHAR(13) + CHAR(10) +
    '2. Call emergency services immediately.' + CHAR(13) + CHAR(10) +
    '3. Place the person on their back on a firm surface.' + CHAR(13) + CHAR(10) +
    '4. Begin chest compressions: 30 compressions at a depth of 2 inches.' + CHAR(13) + CHAR(10) +
    '5. Give 2 rescue breaths after every 30 compressions.',
    'C:\Users\User\Desktop\AidMateVideos\cpr.mp4'
);

-- For Fractures
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Fractures'), 
    'Fracture Treatment',
    '1. Keep the person still and calm.' + CHAR(13) + CHAR(10) +
    '2. Do not move the fractured area unless necessary.' + CHAR(13) + CHAR(10) +
    '3. Immobilize the limb using a splint or sling.' + CHAR(13) + CHAR(10) +
    '4. Apply a cold pack to reduce swelling.' + CHAR(13) + CHAR(10) +
    '5. Elevate the limb if possible.' + CHAR(13) + CHAR(10) +
    '6. Control bleeding with sterile dressing.' + CHAR(13) + CHAR(10) +
    '7. Seek medical help immediately.',
    'C:\Users\User\Desktop\AidMateVideos\fracture.mp4'
);

-- For Choking (corrected version)
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Choking'), 
    'Choking Treatment',
    '1. Ask the person: "Are you choking? Can you speak?"' + CHAR(13) + CHAR(10) +
    '2. If they can''t respond, act immediately.' + CHAR(13) + CHAR(10) +
    '3. Stand behind them and wrap your arms around their waist.' + CHAR(13) + CHAR(10) +
    '4. Perform abdominal thrusts (Heimlich maneuver):' + CHAR(13) + CHAR(10) +
    '   • Make a fist and place it above the navel.' + CHAR(13) + CHAR(10) +
    '   • Grasp the fist with your other hand.' + CHAR(13) + CHAR(10) +
    '   • Pull sharply inward and upward.' + CHAR(13) + CHAR(10) +
    '5. Repeat until the object is expelled or they become unconscious.' + CHAR(13) + CHAR(10) +
    '6. If unconscious, start CPR and call emergency services.',
    'C:\Users\User\Desktop\AidMateVideos\choking.mp4'
);

-- For Nosebleed
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Nosebleed'), 
    'Nosebleed Treatment',
    '1. Sit the person upright and lean forward slightly.' + CHAR(13) + CHAR(10) +
    '2. Pinch the soft part of the nose just below the bridge for 10–15 minutes.' + CHAR(13) + CHAR(10) +
    '3. Breathe through the mouth while pinching.' + CHAR(13) + CHAR(10) +
    '4. Apply a cold compress to the nose or neck.' + CHAR(13) + CHAR(10) +
    '5. Do NOT tilt the head back.' + CHAR(13) + CHAR(10) +
    '6. If bleeding doesn''t stop after 20 minutes, seek medical help.',
    'C:\Users\User\Desktop\AidMateVideos\nosebleed.mp4'
);

-- For Heart Attack
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Heart Attack'), 
    'Heart Attack Treatment',
    '1. Call emergency services immediately.' + CHAR(13) + CHAR(10) +
    '2. Keep the person calm and seated.' + CHAR(13) + CHAR(10) +
    '3. Loosen tight clothing.' + CHAR(13) + CHAR(10) +
    '4. If the person is conscious, give aspirin (if not allergic).' + CHAR(13) + CHAR(10) +
    '5. Begin CPR if they become unconscious and stop breathing.' + CHAR(13) + CHAR(10) +
    '6. Use an AED if available and trained.',
    'C:\Users\User\Desktop\AidMateVideos\heartattack.mp4'
);

-- For Seizure
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Seizure'), 
    'Seizure Treatment',
    '1. Stay calm and clear the area of sharp objects.' + CHAR(13) + CHAR(10) +
    '2. Cushion their head with a folded cloth.' + CHAR(13) + CHAR(10) +
    '3. Turn them gently onto their side.' + CHAR(13) + CHAR(10) +
    '4. Do NOT restrain or put anything in their mouth.' + CHAR(13) + CHAR(10) +
    '5. Time the seizure — if it lasts more than 5 minutes, call emergency services.' + CHAR(13) + CHAR(10) +
    '6. Stay with them until they regain full awareness.',
    'C:\Users\User\Desktop\AidMateVideos\seizure.mp4'
);

-- For Allergic Reaction
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Allergic Reaction'), 
    'Allergic Reaction Treatment',
    '1. Identify the allergen and stop exposure.' + CHAR(13) + CHAR(10) +
    '2. Look for symptoms: swelling, hives, shortness of breath.' + CHAR(13) + CHAR(10) +
    '3. If the person has an epinephrine auto-injector (EpiPen), use it immediately.' + CHAR(13) + CHAR(10) +
    '4. Call emergency services without delay.' + CHAR(13) + CHAR(10) +
    '5. Keep the person lying down and calm.' + CHAR(13) + CHAR(10) +
    '6. Begin CPR if they become unresponsive.',
    'C:\Users\User\Desktop\AidMateVideos\allergy.mp4'
);


-- For Fainting
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Fainting'), 
    'Fainting Treatment',
    '1. Lay the person flat on their back.' + CHAR(13) + CHAR(10) +
    '2. Raise their legs about 12 inches to improve blood flow to the brain.' + CHAR(13) + CHAR(10) +
    '3. Loosen tight clothing.' + CHAR(13) + CHAR(10) +
    '4. Ensure fresh air — open windows or turn on a fan.' + CHAR(13) + CHAR(10) +
    '5. If unconscious for more than a minute, call emergency services.' + CHAR(13) + CHAR(10) +
    '6. Once conscious, help them sit up slowly.',
    'C:\Users\User\Desktop\AidMateVideos\fainting.mp4'
);

-- For Poisoning
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Poisoning'), 
    'Poisoning Treatment',
    '1. Determine the type of poison (if known).' + CHAR(13) + CHAR(10) +
    '2. Call poison control or emergency services immediately.' + CHAR(13) + CHAR(10) +
    '3. Do NOT induce vomiting unless instructed by professionals.' + CHAR(13) + CHAR(10) +
    '4. If inhaled poison: move the person to fresh air.' + CHAR(13) + CHAR(10) +
    '5. If on skin: remove clothing and rinse with water.' + CHAR(13) + CHAR(10) +
    '6. Monitor breathing and consciousness until help arrives.',
    'C:\Users\User\Desktop\AidMateVideos\poisoning.mp4'
);

-- For Electric Shock
INSERT INTO Guides (CategoryId, Title, Instructions, VideoFilePath)
VALUES (
    (SELECT Id FROM Categories WHERE Name = 'Electric Shock'), 
    'Electric Shock Treatment',
    '1. Do NOT touch the person if they are still in contact with electricity.' + CHAR(13) + CHAR(10) +
    '2. Turn off the power source if safe.' + CHAR(13) + CHAR(10) +
    '3. Call emergency services.' + CHAR(13) + CHAR(10) +
    '4. If safe, check for breathing and begin CPR if needed.' + CHAR(13) + CHAR(10) +
    '5. Treat any visible burns.' + CHAR(13) + CHAR(10) +
    '6. Keep the person warm and still until help arrives.',
    'C:\Users\User\Desktop\AidMateVideos\electricshock.mp4'
);
