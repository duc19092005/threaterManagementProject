namespace DataAccess.Enums;

public enum hourScheduleEnum
{
    Morning_0900 = 900,   // 9:00 AM
    Morning_1045 = 1045,  // 10:45 AM
    
    // Matinee / Afternoon Shows (Suất trưa/chiều)
    Matinee_1230 = 1230,  // 12:30 PM (Matinee)
    Afternoon_1415 = 1415, // 2:15 PM
    Afternoon_1600 = 1600, // 4:00 PM
    
    // Evening Shows (Suất tối)
    Evening_1830 = 1830,  // 6:30 PM
    Evening_2045 = 2045,  // 8:45 PM
    LateNight_2230 = 2230, // 10:30 PM
    
    Midnight_0015 = 2415 
}