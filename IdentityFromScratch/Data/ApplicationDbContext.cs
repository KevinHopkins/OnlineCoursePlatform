using IdentityFromScratch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityFromScratch.Data;

public class ApplicationDbContext : IdentityDbContext<Member>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Student> Sudents { get; set; }
    
    public DbSet<Enrolment> Enrolments { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    
    public DbSet<Lessons> Lessons { get; set; }
    
    public DbSet<Objectives> Objectives { get; set; }
    
    public DbSet<Progress> Progress { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Course>().HasData(new Course()
        {
            Id = 1,
            Name = "The Competent Navigator",
            Description = "Map reading and navigation course",
            NetPrice = 499.99m,
            VAT = 100m,
            TotalPrice = 599.99m
        });
        
        modelBuilder.Entity<Lessons>().HasData(new List<Lessons>()
        {
            new Lessons() { Id = 1, CourseId = 1, Name = "Lesson 1 - What is a map?", Header = "A map is simply a bird's eye view of the ground.", Description = "In this lesson we explore the idea of a map as a bird's eye of the ground. Topographical maps represent physical, man-made and relief features and are used for a variety or purposes including land navigation i.e. moving safely and efficiently from one location to another, which is exactly what we will be using them for in this course." },
            new Lessons() { Id = 2, CourseId = 1, Name = "Lesson 2 - What types of maps are there?", Header = "here are paper, laminated, fabric and digital maps.", Description = "In this lesson we explore the pros and cons of each and recommend which type of map you should use and when." },
            new Lessons() { Id = 3, CourseId = 1, Name = "Lesson 3 - What is scale?", Header = "Scale is simply how much smaller the map is compared to the ground the map represents.", Description = "In this lesson we explore maps of different scales to see how much detailed information they contain." },
            new Lessons() { Id = 4, CourseId = 1, Name = "Lesson 4 - What map scales suit which purposes?", Header = "Different map scales suit different purposes and activities.", Description = "In this lesson we explore what map scales are useful for which purposes and activities so that you can select the appropriate scales of maps to plan and execute your outdoor activities." }, 
            new Lessons() { Id = 5, CourseId = 1, Name = "Lesson 5 - What important information is there in the margins of a map?", Header = "Most maps contain important information in the margins of the map.", Description = "In this lesson we explore the margins of a variety of maps to discover the important information that you will need to know when using them for navigation." },
            new Lessons() { Id = 6, CourseId = 1, Name = "Lesson 6 - What are grid references and geographical coordinates?", Header = "To pin point your location on a map and on the ground you will need a unique grid reference or set of geographical coordinates.", Description = "In this lesson we explore grid references and geographical coordinates and how to use them to pin point any location on the map and on the ground." },
            new Lessons() { Id = 7, CourseId = 1, Name = "Lesson 7 - What is direction?", Header = "Direction is measured as an angle from North.", Description = "In this lesson we explore how direction is measured as an angle from North together with the tools we use to measure it, protractors and compasses." },
            new Lessons() { Id = 8, CourseId = 1, Name = "Lesson 8 - What is the Grid Magnetic Angle (GMA)?", Header = "Grid Magnetic Angle (GMA) is the angular difference between grid north and magnetic north.", Description = "In this lesson we explore the Grid Magnetic Angle (GMA), the angular difference between the grid north on your map and the magnetic north measured by your compass. We examine how to make adjustments to bearings to avoid errors as you move them from map to compass and compass to map." },
            new Lessons() { Id = 9, CourseId = 1, Name = "Lesson 9 - What are contour lines?", Header = "Contour lines are lines on the map that delineate points of equal height or elevation.", Description = "In this lesson we explore how contour lines are used to represent elevation and relief. We explore how this provides information on the height and shape of features on the ground and why this is a navigation superpower." },
            new Lessons() { Id = 10, CourseId = 1, Name = "Lesson 10 - How to orientate a map", Header = "An important first step in navigating any leg of your route is to orientate your map to the ground.", Description = "In this lesson we explore how to line up or orientate your map with features on the ground and/or with your compass. In this way what you see in front of you is lined up with what you see on your map which is essential and vital for accurate navigation." },
            new Lessons() { Id = 11, CourseId = 1, Name = "Lesson 11 - How to measure distance on a map", Header = "Distance on a map is measured in mm or cm and then converted to m and km on the ground based on the scale of the map.", Description = "In this lesson we explore how to use a ruler or the side of your compass to measure distance between two points in mm or cm on the map and convert it to distance on the ground in m or km by using the map's scale." },
            new Lessons() { Id = 12, CourseId = 1, Name = "Lesson 12 - How to take a grid bearing from your map", Header = "How to take a grid bearing from the map and convert it to a magnetic bearing on the ground.", Description = "In this lesson we explore how to take a grid bearing and convert it to a magnetic bearing which you will need to follow if you can't see your destination because physical features obscure it, or because of poor visibility at night or in bad weather." },
            new Lessons() { Id = 13, CourseId = 1, Name = "Lesson 13 - How to follow a compass bearing", Header = "If you can't see your destination you will need to follow a compass bearing to get there.", Description = "In this lesson we explore how to walk along and follow a magnetic compass bearing to reach your destination point or target at night or in poor visibility. You may recall we converted this magnetic bearing from a grid bearing we took from the map in the last lesson." },
            new Lessons() { Id = 14, CourseId = 1, Name = "Lesson 14 - How to take a magnetic bearing", Header = "Using your compass to take a magnetic bearing to a feature you can see on the ground.", Description = "In this lesson we explore how to use a compass to take a magnetic bearing to a feature you can see on the ground." },
            new Lessons() { Id = 15, CourseId = 1, Name = "Lesson 15 - How to convert magnetic bearings into back bearings", Header = "Back bearings are 180 degree reversed magnetic bearings important for resections to fix your position.", Description = "In this lesson we explore how to convert magnetic bearings into back bearings in preparation for a resection to fix your position." },
            new Lessons() { Id = 16, CourseId = 1, Name = "Lesson 16 - How to do an intersection to fix any position and a resection to fix your current position.", Header = "How to use bearings to fix any position and back bearings to fix your current position both on the map and on the ground", Description = "In this lesson we explore how to use two or three bearings to fix any position and two to three back bearings to fix your current position on the map and on the ground." },
            new Lessons() { Id = 17, CourseId = 1, Name = "Lesson 17 - How to use collecting features and map memory to thumb a map", Header = "Thumbing the map means keeping your thumb continuously on your current location and mentally ticking off prominent man-made and physical collecting features as you go.", Description = "In this lesson we explore the idea of map memory and using your thumb to mark where you are on the map, and thus the ground, at all times, mentally ticking off prominent collecting features as you go and identify a catching feature to make sure you don’t overshoot and miss your destination point for the current leg of your route." },
            new Lessons() { Id = 18, CourseId = 1, Name = "Lesson 18 - How to use linear man-made and physical features as handrails to guide you on route", Header = "Linear man-made features such as walls, roads and paths or physical features such as rivers and valleys, ridges and coastlines can be used as handrails to navigate by on route to you next destination point.", Description = "In this lesson we explore how you can navigate by walking along linear man-made and physical features on the ground using them literally like a handrail to guide you on route to you next destination." },
            new Lessons() { Id = 19, CourseId = 1, Name = "Lesson 19 - How to calculate time, speed and distance on route", Header = "How far, how fast and what time to your next destination point?", Description = "In this lesson we cover your speed over the ground, how you can estimate distance covered and the duration or time to your next target or destination point." },
            new Lessons() { Id = 20, CourseId = 1, Name = "Lesson 20 - How to avoid compass errors by keeping legs short", Header = "Over short distances, compass errors are small and easily spotted.", Description = "In this lesson we explore the importance of keeping your route sections, or legs, short to avoid compass errors." },
            new Lessons() { Id = 21, CourseId = 1, Name = "Lesson 21 - How to produce a route card to plan ahead", Header = "Plan ahead with a route card and share this with others for safety in case of emergencies.", Description = "In this lesson we explore how to plan out the entire route in advance with a route card and the importance of sharing this with a responsible adult in case of emergencies." },
            new Lessons() { Id = 22, CourseId = 1, Name = "Lesson 22 - Using digital maps to plan a route", Header = "It is easier to plan a route with digital maps.", Description = "In this lesson we explore how to produce the same route card using digital maps." },
            new Lessons() { Id = 23, CourseId = 1, Name = "Lesson 23 - How to do practical navigation", Header = "Putting the theory to practice.", Description = "In this lesson we pull everything together with the 10 Qs and the 5 Ds of practical navigation." },
            new Lessons() { Id = 24, CourseId = 1, Name = "Lesson 24 - How to navigate with digital maps and a GPS", Header = "Using Digital Maps and GPS.", Description = "In this lesson we give a brief introduction to navigating with digital maps and a GPS." },
            new Lessons() { Id = 25, CourseId = 1, Name = "Lesson 25 - How to practice hybrid map reading and navigation", Header = "Don't rely on GPS Alone.", Description = "In this lesson we explore how to use digital maps and a GPS as a secondary backup to confirm the accuracy of your manual map reading, compass work and navigation." },
            new Lessons() { Id = 26, CourseId = 1, Name = "Bonus Lesson - Next Steps", Header = "What next?", Description = "In this bonus lesson we explore what options are open to you to further develop your map reading, compass and navigation skills." }
            
        });
        
        modelBuilder.Entity<Objectives>().HasData(new List<Objectives>()
        {
            new Objectives() {Id = 1, LessonId = 1, Name = "Objective 1.1", Objective = "By the end of this lesson you will understand and be able to describe precisely what maps are and what they are used for."},
            new Objectives() {Id = 2, LessonId = 1, Name = "Objective 1.2", Objective = "By the end of this lesson you will understand that maps use graphics and symbols to represent information about physical, man-made and relief features and their relative position and relationship to one another such that they can be used for safely and efficiently navigating over the land."},
            
            new Objectives() {Id = 3, LessonId = 2, Name = "Objective 2.1", Objective = "By the end of this lesson you will be able to articulate the advantages and disadvantages of each type of map."},
            new Objectives() {Id = 4, LessonId = 2, Name = "Objective 2.2", Objective = "By the end of this lesson you will be able to select maps suitable for your outdoor activities."},
            
            new Objectives() {Id = 5, LessonId = 3, Name = "Objective 3.1", Objective = "By the end of this lesson you will understand and be able to explain what map scales are."},
            new Objectives() {Id = 6, LessonId = 3, Name = "Objective 3.2", Objective = "By the end of this lesson you will be able to explain what 1:25,000, 1:50,000 and 1:250,000 map scales are."},
            
            new Objectives() {Id = 7, LessonId = 4, Name = "Objective 4.1", Objective = "By the end of this lesson you will know what scale of maps are good for planning and which for are good to take into the outdoors for specific pursuits and activities; walking, hiking, running, cycling and canoeing or even sailing."},
            new Objectives() {Id = 8, LessonId = 4, Name = "Objective 4.2", Objective = "By the end of this lesson you will be able to select suitable scales of maps appropriate for your outdoor activities."},         
            
            new Objectives() {Id = 9,  LessonId = 5, Name = "Objective 5.1", Objective = "By the end of this lesson you will understand and be able to use the information in the margins of the map to help you read and interpret the map for navigation purposes."},
            new Objectives() {Id = 10, LessonId = 5, Name = "Objective 5.2", Objective = "By the end of this lesson you will understand and be able find other sources of information to help with navigation in your local area."},   
 
            new Objectives() {Id = 11, LessonId = 6, Name = "Objective 6.1", Objective = "By the end of this lesson you will understand and be able to explain what four, six and eight figure grid references are."},
            new Objectives() {Id = 12, LessonId = 6, Name = "Objective 6.2", Objective = "the end of this lesson you will understand and be able to explain what latitude and longitude coordinates are."},  
            new Objectives() {Id = 13, LessonId = 6, Name = "Objective 6.3", Objective = "By the end of this lesson you will be able use a romer or ruler to measure four, six and eight figure grid references to give your current location or another location on 1:25,000 and 1:50,000 scale maps."},  
            
            new Objectives() {Id = 14, LessonId = 7, Name = "Objective 7.1", Objective = "By the end of this lesson you will understand be able to explain how direction is measured as bearings from North and appreciate the difference between the three Norths, Grid North, True North and Magnetic North."},  
            new Objectives() {Id = 15, LessonId = 7, Name = "Objective 7.2", Objective = "By the end of this lesson you will understand and describe various direction measuring tools such as baseplate compasses, prismatic and lensatic sighting compasses, rulers and protractors."},  
            
            new Objectives() {Id = 16, LessonId = 8, Name = "Objective 8.1", Objective = "By the end of this lesson you will know how to work out the GMA for your local area."},  
            new Objectives() {Id = 17, LessonId = 8, Name = "Objective 8.2", Objective = "By the end of this lesson you will convert magnetic bearings into grid bearings and grid bearings into magnetic bearings by adding or subtracting the GMA for your local area."},  
            
            new Objectives() {Id = 18, LessonId = 9, Name = "Objective 9.1", Objective = "By the end of this lesson you will understand and be able to explain how contour lines join up points of equal height on the land."},  
            new Objectives() {Id = 19, LessonId = 9, Name = "Objective 9.2", Objective = "By the end of this lesson you will be able to interpret the three A's of contour lines and relief; Aspect (the direction of a slope), Altitude (height of the land) and Angle (the steepness of a slope). All this information helps you to visualise the shape of the land before you get there, and how easy or difficulty it is to traverse and how long it may take to get to you next destination point."},             
            new Objectives() {Id = 20, LessonId = 9, Name = "Objective 9.3", Objective = "By the end of this lesson you will be able to recognise and navigate by natural features in the landscape such as spot heights, cols, ridges, rivers and valleys, spurs and reentrants, all very useful features we can use to safely and efficiently navigate over the land."}, 
       
            new Objectives() {Id = 21, LessonId = 10, Name = "Objective 10.1", Objective = "By the end of this lesson you will be able to orient your map using man-made and physical features on the ground."},             
            new Objectives() {Id = 22, LessonId = 10, Name = "Objective 10.2", Objective = "By the end of this lesson you will be able to orient your map using your compass."}, 
            
            new Objectives() {Id = 23, LessonId = 11, Name = "Objective 11.1", Objective = "By the end of this lesson you will be able to measure distance on a 1:25,000 map and convert it accurately to distance on the ground."},             
            new Objectives() {Id = 24, LessonId = 11, Name = "Objective 11.2", Objective = "By the end of this lesson you will be able to measure distance on a 1:50,000 map and convert it accurately to distance on the ground."},   
            
            new Objectives() {Id = 25, LessonId = 12, Name = "Objective 12.1", Objective = "By the end of this lesson you will be able to take a grid bearing from your current location to your next destination point"},             
            new Objectives() {Id = 26, LessonId = 12, Name = "Objective 12.2", Objective = "By the end of this lesson you will be able to convert a grid bearing to a magnetic bearing using the current Grid Magnetic Angle (GMA) for your area."},  
 
            new Objectives() {Id = 27, LessonId = 13, Name = "Objective 13.1", Objective = "By the end of this lesson you will be able to identify prominent features on your magnetic compass bearing that you can walk towards as reference points and thus stay on track to reach your destination."},             
            new Objectives() {Id = 28, LessonId = 13, Name = "Objective 13.2", Objective = "By the end of this lesson you will be able to walk along your compass bearing by taking back bearings to last known positions behind you thus checking you are still on track to reach your destination."},  
            new Objectives() {Id = 29, LessonId = 13, Name = "Objective 13.3", Objective = "By the end of this lesson you will be able to walk along your compass bearing by positioning a member of your group ahead of you on that bearing and then leap frogging them using back bearings and so on until you reach your destination."}, 
      
            new Objectives() {Id = 30, LessonId = 14, Name = "Objective 14.1", Objective = "By the end of this lesson you will be able to select an appropriate sighting compass to take a magnetic bearing.\n\n"},  
            new Objectives() {Id = 31, LessonId = 14, Name = "Objective 14.2", Objective = "By the end of this lesson you will be able to line up your compass sight with a feature on the ground and read off the magnetic bearing from your current location to the feature you can see on the ground."},
            
            new Objectives() {Id = 32, LessonId = 15, Name = "Objective 15.1", Objective = "By the end of this lesson you will be able to convert a magnetic bearing into a back bearing (i.e. the bearing from that feature to your location) by adding 180 degrees where the bearing is less than 180 degree.\n\n"},  
            new Objectives() {Id = 33, LessonId = 15, Name = "Objective 15.2", Objective = "By the end of this lesson you will be able to convert a magnetic bearing into a back bearing (i.e. the bearing from that feature to your location) by subtracting 180 degrees where the bearing is more than 180 degree."},
  
            new Objectives() {Id = 34, LessonId = 16, Name = "Objective 16.1", Objective = "By the end of this lesson you will be able to take a magnetic bearing from your current known position to a feature on the ground whose position you want to fix."},  
            new Objectives() {Id = 35, LessonId = 16, Name = "Objective 16.2", Objective = "By the end of this lesson you will be able to move to another known position to take another magnetic bearing to the same feature on the ground whose position you wish to fix, and repeat for a third if necessary."},
            new Objectives() {Id = 36, LessonId = 16, Name = "Objective 16.3", Objective = "By the end of this lesson you will be able to convert these magnetic bearings into grid bearings using the current Grid Magnetic Angle for your area."},  
            new Objectives() {Id = 37, LessonId = 16, Name = "Objective 16.4", Objective = "By the end of this lesson you will be able to plot each of these grid bearings on the map from their known positions revealing the position of the feature on the map where they intersect."},
            new Objectives() {Id = 38, LessonId = 16, Name = "Objective 16.5", Objective = "By the end of this lesson you will be able to take two to three magnetic bearings to prominent features you can see both on the ground and on your map."},  
            new Objectives() {Id = 39, LessonId = 16, Name = "Objective 16.6", Objective = "By the end of this lesson you will be able to convert the two to three magnetic bearings into back bearings, i.e. the bearings from the two to three prominent features to your location."},
            new Objectives() {Id = 40, LessonId = 16, Name = "Objective 16.7", Objective = "By the end of this lesson you will be able to convert the two to three back bearings into grid bearings by adjusting for the current Grid Magnetic Angle (GMA) in your area."},  
            new Objectives() {Id = 41, LessonId = 16, Name = "Objective 16.8", Objective = "By the end of this lesson you will be able to plot the two to three grid bearings from the two to three prominent features on the map to reveal your location where the lines intersect and thus fix your position."},
   
            new Objectives() {Id = 42, LessonId = 17, Name = "Objective 17.1", Objective = "By the end of this lesson you will be able to identify and memorise a series of prominent collecting features on your route from the map."},
            new Objectives() {Id = 43, LessonId = 17, Name = "Objective 17.2", Objective = "By the end of this lesson you will be able to recognise and tick off each collecting feature as you navigate your route and move your thumb to mark where you are on the map as you go."},  
            new Objectives() {Id = 44, LessonId = 17, Name = "Objective 17.3", Objective = "By the end of this lesson, if you have missed your destination point, you will recognise your catching feature, realise you have missed your destination point, and retrace your steps to find it."},
            
            new Objectives() {Id = 45, LessonId = 18, Name = "Objective 18.1", Objective = "By the end of this lesson you will be able to identify linear man-made and physical features on the map together with collecting features and catch points on route to your destination."},  
            new Objectives() {Id = 46, LessonId = 18, Name = "Objective 18.2", Objective = "By the end of this lesson you will be able to follow linear man-made and physical features on the ground together with collecting features and catch points on route to your destination."},           
 
            new Objectives() {Id = 47, LessonId = 19, Name = "Objective 19.1", Objective = "By the end of this lesson you will know how many steps or paces you walk over a 100m distance and at what speed."},  
            new Objectives() {Id = 48, LessonId = 19, Name = "Objective 19.2", Objective = "By the end of this lesson you will know the number of minutes to add per 10m of elevation gained or 30m of elevation lost."},    
            new Objectives() {Id = 49, LessonId = 19, Name = "Objective 19.3", Objective = "By the end of this lesson you will be able to estimate how long it will take to walk to your next destination, taking into consideration the distance, your speed and the elevation gained or lost on route."},  
            new Objectives() {Id = 50, LessonId = 19, Name = "Objective 19.4", Objective = "By the end of this lesson you will be able to estimate distance walked by pacing and keeping track of each 100m section of ground covered based on your personal and known measure of the number of steps you walk over a 100m distance."},   

            new Objectives() {Id = 51, LessonId = 20, Name = "Objective 20.1", Objective = "By the end of this lesson you will be able to calculate the effect of compass errors over various distances."},  
            new Objectives() {Id = 52, LessonId = 20, Name = "Objective 20.2", Objective = "By the end of this lesson you will be able to assess the risk of errors over short distances and whether to accept or mitigate such errors."},   
            
            new Objectives() {Id = 53, LessonId = 21, Name = "Objective 21.1", Objective = "By the end of this lesson you will be able to plan out and draw up a route card with waypoints/destination points, bearings, distances, elevation gained and lost and timings for each leg."},  
            new Objectives() {Id = 54, LessonId = 21, Name = "Objective 21.2", Objective = "By the end of this lesson you will understand the importance of sharing your route card with a responsible adult in case of emergencies."},   
            new Objectives() {Id = 55, LessonId = 21, Name = "Objective 21.3", Objective = "By the end of this lesson you will understand the importance of sticking to your planned route so, in case emergencies, the alarm can be raised and emergency services have a fighting chance of finding you."},  
            
            new Objectives() {Id = 56, LessonId = 22, Name = "Objective 22.1", Objective = "By the end of this lesson you will be able to set waypoints and plan a route with distances and bearings, elevation gained and lost together with timings.\n\n"},  
            new Objectives() {Id = 57, LessonId = 22, Name = "Objective 22.2", Objective = "By the end of this lesson you will be able to export your route plan as a GPX file and import this file into other GPS devices."},   
            new Objectives() {Id = 58, LessonId = 22, Name = "Objective 22.3", Objective = "By the end of this lesson you will be able print off route card to share with others in case of emergencies."},  
            
            new Objectives() {Id = 59, LessonId = 23, Name = "Objective 23.1", Objective = "By the end of this lesson you will know the 10 Qs or questions you need to ask as you move from one location, your start point to another location, your destination point, for each leg of your route."},  
            new Objectives() {Id = 60, LessonId = 23, Name = "Objective 23.2", Objective = "By the end of this lesson you will know the 5 Ds of navigation, Destination, Distance, Duration, Direction and Description and how to apply them to navigate safely and efficiently."},   
            new Objectives() {Id = 61, LessonId = 23, Name = "Objective 23.3", Objective = "By the end of this lesson you will be able to pull together into a coherent whole all the skills learned so far and apply them effectively to navigate safely and efficiently in lowland landscapes in good visibility."}, 
            
            new Objectives() {Id = 62, LessonId = 24, Name = "Objective 24.1", Objective = "By the end of this lesson you will be able to select an appropriate digital map and GPS device."},   
            new Objectives() {Id = 63, LessonId = 24, Name = "Objective 24.2", Objective = "By the end of this lesson you will be able to use a digital map and navigate by GPS."}, 
            
            new Objectives() {Id = 64, LessonId = 25, Name = "Objective 25.1", Objective = "By the end of this lesson you will be able to navigate first and foremost using a paper, laminated or fabric map and compass."},   
            new Objectives() {Id = 65, LessonId = 25, Name = "Objective 25.2", Objective = "By the end of this lesson you will be able to check your manual map reading and navigation efforts using your GPS thus setting up a positive reinforcement loop to further develop your skills as a competent navigator."}, 
            
            new Objectives() {Id = 66, LessonId = 26, Name = "Objective", Objective = "By the end of this lesson you will know where to go and how to further develop your newly acquired manual map reading, compass and navigation skills to navigate in more challenging environments such as upland areas and in reduced visibility conditions."} 

        });
    }
}