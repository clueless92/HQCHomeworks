package pr030405Barracks.core;

import pr030405Barracks.contracts.*;
import pr030405Barracks.contracts.Executable;
import pr030405Barracks.core.commands.*;

import java.lang.reflect.*;

public class CommandInterpreterImpl implements CommandInterpreter {

	private static final String COMMANDS_PACKAGE = "pr030405Barracks.core.commands.";

	private Repository repository;
	private UnitFactory unitFactory;

	public CommandInterpreterImpl(Repository repository, UnitFactory unitFactory) {
		this.repository = repository;
		this.unitFactory = unitFactory;
	}

	public Executable interpretCommand(String[] data, String commandName) {
		char firstChar = (char) (commandName.charAt(0) - ('a' - 'A'));
		commandName = COMMANDS_PACKAGE + firstChar + commandName.substring(1) + "Command";

		Executable commandInstance = null;
		try {
			Class<Command> commandClass = (Class<Command>) Class.forName(commandName);
			Constructor ctor = commandClass.getConstructor(String[].class);
			commandInstance = (Command) ctor.newInstance((Object) data);
			this.injectDependencies(commandInstance, commandClass);
		} catch (ReflectiveOperationException e) {
			e.printStackTrace();
		}
		return commandInstance;
	}

	private void injectDependencies(Executable commandInstance,
									Class<Command> commandClass) throws
			IllegalAccessException {
		Field[] cmdFields = commandClass.getDeclaredFields();
		Field[] theseFields = CommandInterpreterImpl.class.getDeclaredFields();

		for (Field field : cmdFields) {
			if (!field.isAnnotationPresent(Inject.class)) {
				continue;
			}
			field.setAccessible(true);

			for (Field thisField : theseFields) {
				if (!thisField.getType().equals(field.getType())) {
					continue;
				}
				thisField.setAccessible(true);
				field.set(commandInstance, thisField.get(this));
			}
		}
	}
}
