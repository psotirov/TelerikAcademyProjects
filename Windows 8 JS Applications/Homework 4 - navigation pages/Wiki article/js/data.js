// Binding.List passed as the 'dataSource' argument in the ListViews
(function () {
    "use strict";
    var articles = [
        // Item 0
        "<ul><li>50: Hero's Engine (<i>aeolipile</i>)&nbsp;— Apparently, Hero's steam engine was taken to be no more than a toy, and thus its full potential not realized for centuries.</li><li>1500: The \"Chimney Jack\" was drawn by >Leonardo da Vinci: Hot air from a fire rises through a single-stage axial turbine rotor mounted in the exhaust duct of the fireplace and turning the roasting spit by gear/ chain connection.</li>"+
        "<li>1629: Jets of steam rotated an impulse turbine that then drove a working stamping mill by means of a bevel gear, developed by Giovanni Branca.</li>" +
        "<li>1678: Ferdinand Verbiest built a model carriage relying on a steam jet for power." +
            "<div><div style=\"width:192px;\"><img alt=\"\" src=\"/images/john-barbers-gas-turbine.jpg\" width=\"190\" height=\"210\" /><div>Sketch of John Barber's gas turbine, from his patent</div></div>" + 
        "<li>1791: A patent was given to John Barber, an Englishman, for the first true gas turbine. His invention had most of the elements present in the modern day gas turbines. The turbine was designed to power a horseless carriage.</li>"+
        "<li>1872: A gas turbine engine was designed by Franz Stolze, but the engine never ran under its own power.</li>"+
        "<li>1894: Sir Charles Parsons patented the idea of propelling a ship with a steam turbine, and built a demonstration vessel, the <i>Turbinia</i>, easily the fastest vessel afloat at the time. This principle of propulsion is still of some use.</li>" +
        "<li>1895: Three 4-ton 100&nbsp;kW Parsons radial flow generators were installed in Cambridge Power Station, and used to power the first electric street lighting scheme in the city.</li>" +
        "<li>1899: Charles Gordon Curtis patented the first gas turbine engine in the USA (\"Apparatus for generating mechanical power\", Patent No. US635,919).</li>" +
        "<li>1900: Sanford Alexander Moss submitted a thesis on gas turbines. In 1903, Moss became an engineer for General Electric's Steam Turbine Department in Lynn, Massachusetts. While there, he applied some of his concepts in the development of the turbosupercharger. His design used a small turbine wheel, driven by exhaust gases, to turn a supercharger.</li>" +
        "<li>1903: A Norwegian, Ægidius Elling, was able to build the first gas turbine that was able to produce more power than needed to run its own components, which was considered an achievement in a time when knowledge about aerodynamics was limited. Using rotary compressors and turbines it produced 11&nbsp;hp (massive for those days).</li>" +
        "<li>1906: The Armengaud-Lemale turbine engine in France with water-cooled combustion chamber.</li>" +
        "<li>1910: Holzwarth impulse turbine (pulse combustion) achieved 150 kilowatts.</li>" +
        "<li>1913: Nikola Tesla</a> patents the Tesla turbine based on the boundary layer effect.</li>" +
        "<li>1920s The practical theory of gas flow through passages was developed into the more formal (and applicable to turbines) theory of gas flow past airfoils by A. A. Griffith resulting in the publishing in 1926 of <i>An Aerodynamic Theory of Turbine Design</i>. Working testbed designs of axial turbines suitable for driving a propellor were developed by the Royal Aeronautical Establishment proving the efficiency of aerodynamic shaping of the blades in 1929.</li>" +
        "<li>1930: Having found no interest from the RAF for his idea, Frank Whittle patented the design for a centrifugal gas turbine for jet propulsion. The first successful use of his engine was in April 1937.</li>" +
        "<li>1932: BBC Brown, Boveri &amp; Cie of Switzerland starts selling axial compressor and turbine turbosets as part of the turbocharged steam generating Velox boiler. Following the gas turbine principle, the steam evaporation tubes are arranged within the gas turbine combustion chamber; the first Velox plant was erected in Mondeville, France.</li>" +
        "<li>1934: Raúl Pateras de Pescara patented the free-piston engine as a gas generator for gas turbines.</li>" +
        "<li>1936: Hans von Ohain and Max Hahn in Germany were developing their own patented engine design.</li>" +
        "<li>1936 Whittle with others backed by investment forms Power Jets Ltd</li>" +
        "<li>1937, the first Power Jets engine runs, and impresses Henry Tizard such that he secures government funding for its further development.</li>" +
        "<li>1939: First 4 MW utility power generation gas turbine from BBC Brown, Boveri &amp; Cie. for an emergency power station in Neuchâtel, Switzerland.</li>" +
        "<li>1946: National Gas Turbine Establishment formed from Power Jets and the RAE turbine division bring together Whittle and Hayne Constant's work</li></ul>",

        // Item 1
        "<p>Gases passing through an ideal gas turbine undergo three thermodynamic processes. These are isentropic compression, isobaric (constant pressure) combustion and isentropic expansion. Together, these make up the Brayton cycle.<p>" +
        "<p>In a practical gas turbine, gases are first accelerated in either a centrifugal or axial compressor. These gases are then slowed using a diverging nozzle known as a diffuser; these processes increase the pressure and temperature of the flow. In an ideal system, this is isentropic. However, in practice, energy is lost to heat, due to friction and turbulence. Gases then pass from the diffuser to a combustion chamber, or similar device, where heat is added. In an ideal system, this occurs at constant pressure (isobaric heat addition). As there is no change in pressure the specific volume of the gases increases. In practical situations this process is usually accompanied by a slight loss in pressure, due to friction. Finally, this larger volume of gases is expanded and accelerated by nozzle guide vanes before energy is extracted by a turbine. In an ideal system, these gases are expanded isentropically and leave the turbine at their original pressure. In practice this process is not isentropic as energy is once again lost to friction and turbulence.</p>" +
        "<p>If the device has been designed to power a shaft as with an industrial generator or a turboprop, the exit pressure will be as close to the entry pressure as possible. In practice it is necessary that some pressure remains at the outlet in order to fully expel the exhaust gases. In the case of a jet engine only enough pressure and energy is extracted from the flow to drive the compressor and other components. The remaining high pressure gases are accelerated to provide a jet that can, for example, be used to propel an aircraft.</p>" +
        "Brayton cycle" +
        "<p>As with all cyclic heat engines, higher combustion temperatures can allow for greater efficiencies. However, temperatures are limited by ability of the steel, nickel, ceramic, or other materials that make up the engine to withstand high temperatures and stresses. To combat this many turbines feature complex blade cooling systems.</p>" +
        "<p>As a general rule, the smaller the engine, the higher the rotation rate of the shaft(s) must be to maintain tip speed. Blade-tip speed determines the maximum pressure ratios that can be obtained by the turbine and the compressor. This, in turn, limits the maximum power and efficiency that can be obtained by the engine. In order for tip speed to remain constant, if the diameter of a rotor is reduced by half, the rotational speed must double. For example, large jet engines operate around 10,000 rpm, while micro turbines spin as fast as 500,000 rpm.</p>" +
        "<p>Mechanically, gas turbines can be considerably less complex than internal combustion piston engines. Simple turbines might have one moving part: the shaft/compressor/turbine/alternative-rotor assembly (see image above), not counting the fuel system. However, the required precision manufacturing for components and temperature resistant alloys necessary for high efficiency often make the construction of a simple turbine more complicated than piston engines.</p>" +
        "<p>More sophisticated turbines (such as those found in modern jet engines) may have multiple shafts (spools), hundreds of turbine blades, movable stator blades, and a vast system of complex piping, combustors and heat exchangers.</p>" +
        "<p>Thrust bearings and journal bearings are a critical part of design. Traditionally, they have been hydrodynamic oil bearings, or oil-cooled ball bearings. These bearings are being surpassed by foil bearings, which have been successfully used in micro turbines and auxiliary power units.</p>",

        // Item 2
        "<h3>Jet engines</h3>" +
        "<p>A typical axial-flow gas turbine turbojet, the J85, sectioned for display. Flow is left to right, multistage compressor on left, combustion chambers center, two-stage turbine on right.</p>" +
        "<p>Airbreathing jet engines are gas turbines optimized to produce thrust from the exhaust gases, or from ducted fans connected to the gas turbines. Jet engines that produce thrust from the direct impulse of exhaust gases are often called turbojets, whereas those that generate thrust with the addition of a ducted fan are often called turbofans or (rarely) fan-jets.</p>" +
        "<p>Gas turbines are also used in many liquid propellant rockets, the gas turbines are used to power a turbopump to permit the use of lightweight, low pressure tanks, which saves considerable dry mass.</p>" +
        "<h3>Turboprop engines</h3>" +
        "<p>A turboprop engine is a type of turbine engine which drives an external aircraft propeller using a reduction gear. Turboprop engines are generally used on small subsonic aircraft, but some large military and civil aircraft, such as the Airbus A400M, Lockheed L-188 Electra and Tupolev Tu-95, have also used turboprop power.</p>" +
        "<h3>Aeroderivative gas turbines</h3>" +


        "Diagram of a high-pressure turbine blade" +
        "<p>Aeroderivatives are also used in electrical power generation due to their ability to be shut down, and handle load changes more quickly than industrial machines. They are also used in the marine industry to reduce weight. The General Electric LM2500, General Electric LM6000, Rolls-Royce RB211 and Rolls-Royce Avon are common models of this type of machine.</p>" +
        "<h3>Amateur gas turbines</h3>" +
        "<p>Increasing numbers of gas turbines are being used or even constructed by amateurs.</p>" +
        "<p>In its most straightforward form, these are commercial turbines acquired through military surplus or scrapyard sales, then operated for display as part of the hobby of engine collecting. In its most extreme form, amateurs have even rebuilt engines beyond professional repair and then used them to compete for the Land Speed Record.</p>" +
        "<p>The simplest form of self-constructed gas turbine employs an automotive turbocharger as the core component. A combustion chamber is fabricated and plumbed between the compressor and turbine sections.</p>" +
        "<p>More sophisticated turbojets are also built, where their thrust and light weight are sufficient to power large model aircraft. The Schreckling design[12] constructs the entire engine from raw materials, including the fabrication of a centrifugal compressor wheel from plywood, epoxy and wrapped carbon fibre strands.</p>" +
        "<p>Several small companies now manufacture small turbines and parts for the amateur. Most turbojet-powered model aircraft are now using these commercial and semi-commercial microturbines, rather than a Schreckling-like home-build.</p>" +
        "<h3>Auxiliary power units</h3>" +
        "<p>APUs are small gas turbines designed to supply auxiliary power to larger, mobile, machines such as an aircraft. They supply:</p>" +
        "<ul><li>compressed air for air conditioning and ventilation,</li>" +
        "<li>compressed air start-up power for larger jet engines,</li>" +
        "<li>mechanical (shaft) power to a gearbox to drive shafted accessories or to start large jet engines, and</li>" +
        "<li>electrical, hydraulic and other power-transmission sources to consuming devices remote from the APU.</li></ul>" +
        "<h3>Industrial gas turbines for power generation</h3>" +


        "GE H series power generation gas turbine: in combined cycle configuration, this 480-megawatt unit has a rated thermal efficiency of 60%." +
        "<p>Industrial gas turbines differ from aeronautical designs in that the frames, bearings, and blading are of heavier construction. They are also much more closely integrated with the devices they power—electric generator—and the secondary-energy equipment that is used to recover residual energy (largely heat).</p>" +
        "<p>They range in size from man-portable mobile plants to enormous, complex systems weighing more than a hundred tonnes housed in block-sized buildings. When the turbine is used solely for shaft power, its thermal efficiency is around the 30% mark. This may cause a problem in which it is cheaper to buy electricity than to burn fuel. Therefore many engines are used in CHP (Combined Heat and Power) configurations that can be small enough to be integrated into portable container configurations.</p>" +
        "<p>Gas turbines can be particularly efficient—up to at least 60%—when waste heat from the turbine is recovered by a heat recovery steam generator to power a conventional steam turbine in a combined cycle configuration.[14][15] They can also be run in a cogeneration configuration: the exhaust is used for space or water heating, or drives an absorption chiller for cooling or refrigeration.</p>" +
        "<p>Another significant advantage is their ability to be turned on and off within minutes, supplying power during peak, or unscheduled, demand. Since single cycle (gas turbine only) power plants are less efficient than combined cycle plants, they are usually used as peaking power plants, which operate anywhere from several hours per day to a few dozen hours per year—depending on the electricity demand and the generating capacity of the region. In areas with a shortage of base-load and load following power plant capacity or with low fuel costs, a gas turbine powerplant may regularly operate most hours of the day. A large single-cycle gas turbine typically produces 100 to 400 megawatts of electric power and has 35–40% thermal efficiency.</p>" +
        "<h3>Industrial gas turbines for mechanical drive</h3>" +
        "<p>Industrial gas turbines that are used solely for mechanical drive or used in collaboration with a recovery steam generator differ from power generating sets in that they are often smaller and feature a \"twin\" shaft design as opposed to a single shaft. The power range varies from 1 megawatt up to 50 megawatts.[citation needed] These engines are connected via a gearbox to either a pump or compressor assembly, the majority of installations are used within the oil and gas industries. Mechanical drive applications provide a more efficient combustion raising around 2%.</p>" +
        "<p>Oil and Gas platforms require these engines to drive compressors to inject gas into the wells to force oil up via another bore, they're also often used to provide power for the platform. These platforms don't need to use the engine in collaboration with a CHP system due to getting the gas at an extremely reduced cost (often free from burn off gas). The same companies use pump sets to drive the fluids to land and across pipelines in various intervals.</p>" +
        "<h3>Compressed air energy storage</h3>" +
        "<p>One modern development seeks to improve efficiency in another way, by separating the compressor and the turbine with a compressed air store. In a conventional turbine, up to half the generated power is used driving the compressor. In a compressed air energy storage configuration, power, perhaps from a wind farm or bought on the open market at a time of low demand and low price, is used to drive the compressor, and the compressed air released to operate the turbine when required.</p>" +
        "<h3>Turboshaft engines</h3>" +
        "<p>Turboshaft engines are often used to drive compression trains (for example in gas pumping stations or natural gas liquefaction plants) and are used to power almost all modern helicopters. The primary shaft bears the compressor and the high speed turbine (often referred to as the Gas Generator), while a second shaft bears the low-speed turbine (a power turbine or free-wheeling turbine on helicopters, especially, because the gas generator turbine spins separately from the power turbine). In effect the separation of the gas generator, by a fluid coupling (the hot energy-rich combustion gases), from the power turbine is analogous to an automotive transmission's fluid coupling. This arrangement is used to increase power-output flexibility with associated highly-reliable control mechanisms.</p>" +
        "<h3>Radial gas turbines</h3>" +
        "<p>In 1963, Jan Mowill initiated the development at Kongsberg Våpenfabrikk in Norway. Various successors have made good progress in the refinement of this mechanism. Owing to a configuration that keeps heat away from certain bearings the durability of the machine is improved while the radial turbine is well matched in speed requirement.</p>" +
        "<h3>Scale jet engines</h3>" +


        "<p>Scale jet engines are scaled down versions of this early full scale engine</p>" +
        "<p>Also known as miniature gas turbines or micro-jets.</p>" +
        "<p>With this in mind the pioneer of modern Micro-Jets, Kurt Schreckling, produced one of the world's first Micro-Turbines, the FD3/67. This engine can produce up to 22 newtons of thrust, and can be built by most mechanically minded people with basic engineering tools, such as a metal lathe.</p>" +
        "<h3>Microturbines</h3>" +
        "<p>Also known as:" +
        "<ul><li>Turbo alternators</li>" +
        "<li>Turbogenerator</li></ul></p>" +
        "<p>Microturbines are touted to become widespread in distributed power and combined heat and power applications. They are one of the most promising technologies for powering hybrid electric vehicles. They range from hand held units producing less than a kilowatt, to commercial sized systems that produce tens or hundreds of kilowatts. Basic principles of microturbine are based on micro combustion.</p>" +
        "<p>Part of their claimed success is said to be due to advances in electronics, which allows unattended operation and interfacing with the commercial power grid. Electronic power switching technology eliminates the need for the generator to be synchronized with the power grid. This allows the generator to be integrated with the turbine shaft, and to double as the starter motor.</p>" +
        "<p>Microturbine systems have many claimed advantages over reciprocating engine generators, such as higher power-to-weight ratio, low emissions and few, or just one, moving part. Advantages are that microturbines may be designed with foil bearings and air-cooling operating without lubricating oil, coolants or other hazardous materials. Nevertheless reciprocating engines overall are still cheaper when all factors are considered.[original research?] Microturbines also have a further advantage of having the majority of the waste heat contained in the relatively high temperature exhaust making it simpler to capture, whereas the waste heat of reciprocating engines is split between its exhaust and cooling system.</p>" +
        "<p>However, reciprocating engine generators are quicker to respond to changes in output power requirement and are usually slightly more efficient, although the efficiency of microturbines is increasing. Microturbines also lose more efficiency at low power levels than reciprocating engines.</p>" +
        "<p>Reciprocating engines typically use simple motor oil (journal) bearings. Full-size gas turbines often use ball bearings. The 1000°C temperatures and high speeds of microturbines make oil lubrication and ball bearings impractical; they require air bearings or possibly magnetic bearings.</p>" +
        "<p>When used in extended range electric vehicles the static efficiency drawback is irrelevant, since the gas turbine can be run at or near maximum power, driving an alternator to produce electricity either for the wheel motors, or for the batteries, as appropriate to speed and battery state. The batteries act as a \"buffer\" (energy storage) in delivering the required amount of power to the wheel motors, rendering throttle response of the gas turbine completely irrelevant.</p>" +
        "<p>There is, moreover, no need for a significant or variable-speed gearbox; turning an alternator at comparatively high speeds allows for a smaller and lighter alternator than would otherwise be the case. The superior power-to-weight ratio of the gas turbine and its fixed speed gearbox, allows for a much lighter prime mover than those in such hybrids as the Toyota Prius (which utilised a 1.8 litre petrol engine) or the Chevrolet Volt (which utilises a 1.4 litre petrol engine). This in turn allows a heavier weight of batteries to be carried, which allows for a longer electric-only range. Alternatively, the vehicle can use heavier types of batteries such as lead acid batteries (which are cheaper to buy) or safer types of batteries such as Lithium-Iron-Phosphate.</p>" +
        "<p>When gas turbines are used in extended-range electric vehicles, like those planned by Land-Rover/Range-Rover in conjunction with Bladon, or by Jaguar also in partnership with Bladon, the very poor throttling response (their high moment of rotational inertia) does not matter, because the gas turbine, which may be spinning at 100,000 rpm, is not directly, mechanically connected to the wheels. It was this poor throttling response that so bedevilled the 1960 Rover gas turbine-powered prototype motor car, which did not have the advantage of an intermediate electric drive train.</p>" +
        "<p>Gas turbines accept most commercial fuels, such as petrol, natural gas, propane, diesel, and kerosene as well as renewable fuels such as E85, biodiesel and biogas. However, when running on kerosene or diesel, starting sometimes requires the assistance of a more volatile product such as propane gas - although the new kero-start technology can allow even microturbines fuelled on kerosene to start without propane.</p>" +
        "<p>Microturbine designs usually consist of a single stage radial compressor, a single stage radial turbine and a recuperator. Recuperators are difficult to design and manufacture because they operate under high pressure and temperature differentials. Exhaust heat can be used for water heating, space heating, drying processes or absorption chillers, which create cold for air conditioning from heat energy instead of electric energy.</p>" +
        "<p>Typical microturbine efficiencies are 25 to 35%. When in a combined heat and power cogeneration system, efficiencies of greater than 80% are commonly achieved.</p>" +
        "<p>MIT started its millimeter size turbine engine project in the middle of the 1990s when Professor of Aeronautics and Astronautics Alan H. Epstein considered the possibility of creating a personal turbine which will be able to meet all the demands of a modern person's electrical needs, just as a large turbine can meet the electricity demands of a small city.</p>" +
        "<p>Problems have occurred with heat dissipation and high-speed bearings in these new microturbines. Moreover, their expected efficiency is a very low 5-6%. According to Professor Epstein, current commercial Li-ion rechargeable batteries deliver about 120-150 W·h/kg. MIT's millimeter size turbine will deliver 500-700 W·h/kg in the near term, rising to 1200-1500 W∙h/kg in the longer term.</p>" +
        "<p>A similar microturbine built at in Belgium has a rotor diameter of 20 mm and is expected to produce about 1000 W.</p>"
    ];

    var dataList = new WinJS.Binding.List([
        { title: "History", text: "Development through centuries", picture: "/images/john-barbers-gas-turbine.jpg", content: articles[0] },
        { title: "Theory of operation", text: "Introducing Brayton Cylce", picture: "/images/brayton-cycle.png", content: articles[1] },
        { title: "Types", text: "Different types of gas turbines", picture: "/images/turbojet-engine.jpg", content: articles[2] }
    ]);



    // Create a namespace to make the data publicly
    // accessible. 
    var publicMembers =
        {
            items: dataList,
            articles: articles
        };
    WinJS.Namespace.define("TableOfContents", publicMembers);

})();
