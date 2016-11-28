package pr030405Barracks;

import pr030405Barracks.contracts.CommandInterpreter;
import pr030405Barracks.contracts.Repository;
import pr030405Barracks.contracts.Runnable;
import pr030405Barracks.contracts.UnitFactory;
import pr030405Barracks.core.CommandInterpreterImpl;
import pr030405Barracks.core.Engine;
import pr030405Barracks.core.factories.UnitFactoryImpl;
import pr030405Barracks.data.UnitRepository;

public class Main {

	public static void main(String[] args) {
		Repository repository = new UnitRepository();
		UnitFactory unitFactory = new UnitFactoryImpl();
		CommandInterpreter commandInterpreter =
				new CommandInterpreterImpl(repository, unitFactory);
		Runnable engine = new Engine(commandInterpreter);
		engine.run();
	}
}
