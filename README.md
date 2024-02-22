# StrategyPattern-Based-FPS-Player-Attack-Mechanic
Strategy Pattern ile FPS Player'ın farklı algoritmalar içeren saldırı metodlarını çalıştıran bir prototipi içeren repo'dur.<br>
1/2/3 numara tuşları ile oyuncu silah türü değiştirebilir. <br><br>

<b>---WEAPON STRATEGY---</b><br>
<b>WeaponStrategy.cs</b> => Bu scriptable object, her bir weapon türünün türetileceği base class'tır.<br>
<b>BulletStrategy.cs</b> => Bu Strategy, IWeapon tipinde bir silahın kullanılması logic'inin çalıştırılmasını içerir.<br>
<b>ThrowStrategy.cs</b> => Bu Strategy, IWeaponThrowable tipinde bir silahın kullanılması logic'inin çalıştırılmasını içerir.<br>
<b>VaultStrategy.cs</b> => Bu Strategy, IVaultableWeapon tipinde bir silahın kullanılması logic'inin çalıştırılmasını içerir.<br>
<b>WeaponController.cs</b> => Daha önceki versiyonlarda tanımlanmış bu sınıfta, ek olarak EquipWeapon metodu eklenmiştir. Bu metod seçilen WeaponStrategy'yi currentWeapon'a atama yaparak silahı değiştirmiş olur. UseWeapon metoduyla silah kullanıldığında, currentWeapon'ın FireEvent metodu çağırılarak, seçilmiş olan Weapon Strategy logic'i çalıştırılmış olur.<br>
<b>WeaponInputController.cs</b> => Player input'unun alındığı sınıftır. Alınan input'a göre WeaponController'da silah değişimi yapılır.
