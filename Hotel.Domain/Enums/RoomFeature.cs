namespace Hotel.Domain.Enums;

[Flags]
public enum RoomFeature
{
    AirConditioning = 1,
    Patio = 2,
    PrivateBathroom = 4,
    FlatScreenTv = 8,
    Soundproofing = 16,
    CoffeeMachine = 32,
    Minibar = 64,
    FreeWiFi = 128
}