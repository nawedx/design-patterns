## Challenge: Game Character Creation System

**Scenario**: You're building a fantasy RPG game where players can create characters in different game modes. Each game mode has different rules, available classes, and character creation processes.

**Requirements**:

1. **Character Classes**: Warrior, Mage, Archer, Rogue, Paladin, Necromancer

2. **Game Modes**:
    - `CasualModeCreator` - Easy mode with boosted stats (Warrior, Mage, Archer only)
    - `HardcoreModeCreator` - Realistic stats, permadeath (All classes except Necromancer)
    - `PvPModeCreator` - Balanced for player vs player (Warrior, Mage, Archer, Rogue only)
    - `CampaignModeCreator` - Story mode with special abilities (All classes available)

3. **Each character should have**:
    - `string Name`
    - `int Health, Mana, Strength, Agility, Intelligence`
    - `List<string> Abilities`
    - `string Difficulty` (Easy/Normal/Hard/Nightmare)

4. **Character Methods**:
    - `void DisplayStats()` - Show character information
    - `void LevelUp()` - Increase stats based on class
    - `void UseAbility(string abilityName)` - Use a specific ability
    - `bool CanUseAbility(string abilityName)` - Check if ability is available

## The Twist 🔥 (This Makes It Challenging):

5. **Mode-Specific Character Variations**:
    - **Casual Warrior**: +50% health, starts with "Shield Bash" and "Berserker Rage"
    - **Hardcore Warrior**: Normal stats, starts with "Survival Instinct" only
    - **PvP Warrior**: Balanced stats, starts with "Taunt" and "Counter Attack"
    - **Campaign Warrior**: Normal stats, starts with "Heroic Strike" and story-specific "Rally Troops"

6. **Dynamic Stat Calculation** based on mode:
    - Casual: All stats × 1.5
    - Hardcore: All stats × 0.8
    - PvP: Balanced (normal stats)
    - Campaign: Normal stats + special campaign bonuses

7. **Advanced Requirements**:
    - Characters should remember which mode they were created in
    - Some abilities are mode-specific and shouldn't work in other contexts
    - Level-up progression should be different per mode
    - Add validation: Can't create unsupported class in certain modes

## What This Tests:

1. **Complex Factory Method usage** - Same class, different implementations per mode
2. **Strategy Pattern integration** - Different stat calculation strategies
3. **State management** - Characters remembering their creation context
4. **Validation logic** - Mode restrictions
5. **Polymorphism depth** - Same interface, very different behaviors

## Expected Usage:

```csharp
// Should work like this:
var casualCreator = new CasualModeCreator();
var easyWarrior = casualCreator.CreateCharacter("warrior", "Conan");

var hardcoreCreator = new HardcoreModeCreator();
var hardWarrior = hardcoreCreator.CreateCharacter("warrior", "Guts");

// These should be VERY different even though both are "warriors"
easyWarrior.DisplayStats();   // Should show boosted stats
hardWarrior.DisplayStats();   // Should show reduced stats

easyWarrior.UseAbility("Shield Bash");      // Should work
hardWarrior.UseAbility("Shield Bash");      // Should fail - not available in hardcore

// Should handle validation:
hardcoreCreator.CreateCharacter("necromancer", "BadGuy"); // Should throw exception
```

## Bonus Challenges 🚀:

- **Character Migration**: Allow moving characters between modes (with stat adjustments)
- **Ability Cooldowns**: Some abilities can only be used once per level
- **Equipment System**: Different modes allow different starting equipment
- **Save/Load**: Serialize characters with their mode information

## Think About:

1. **How do you handle the same class (Warrior) having different implementations per mode?**
2. **Where does the stat calculation logic belong?**
3. **How do you validate class availability per mode?**
4. **What's the best way to handle mode-specific abilities?**

This challenge tests whether you can:
- Use Factory Method for complex object creation
- Handle multiple variations of the same object type
- Integrate business logic cleanly
- Design for extensibility (adding new modes/classes)

The key insight: **You might need different Warrior classes for different modes** (CasualWarrior, HardcoreWarrior, etc.) OR you might handle differences through **composition/strategy patterns**.

Take your time to think about the design before coding. This is closer to real-world complexity where Factory Method interacts with other patterns and business requirements.

**How would you approach this?** What would your class hierarchy look like?