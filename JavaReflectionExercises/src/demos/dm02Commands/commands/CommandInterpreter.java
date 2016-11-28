package demos.dm02Commands.commands;

import java.lang.reflect.*;

public class CommandInterpreter {

	private static final String COMMANDS_PACKAGE = "demos.dm02Commands.commands.";

	private StringBuilder builder;
	private Thread thread;

	public CommandInterpreter(StringBuilder builder, Thread thread) {
		this.builder = builder;
		this.thread = thread;
	}

	public Executable interpretCommand(String commandName, String[] data) {

		Executable exe = null;
		try {
			Class<Executable> exeClass = (Class<Executable>) Class.forName(COMMANDS_PACKAGE + commandName + "Command");
			Constructor ctor = exeClass.getDeclaredConstructor(String[].class);
			exe = (Executable) ctor.newInstance((Object) data);
//			this.resolveDependancies(exe, exeClass);
		} catch (ReflectiveOperationException rfe) {
			throw new RuntimeException("Invalid command!");
//			rfe.printStackTrace();
		}

		return exe;

//		Executable command = null;
//		switch (commandName) {
//			case "PrintIntCommand":
//				command = new PrintIntCommand(data);
//				break;
//			case "PrintDoubleCommand":
//				command = new PrintDoubleCommand(data);
//				break;
//			case "End":
//				command = new EndCommand(data);
//				break;
//			default:
//				throw new RuntimeException("Invalid command!");
//		}
//
//		return command;
	}

	private void resolveDependancies(Executable exe, Class<Executable> exeClass)
			throws IllegalAccessException {
		Field[] fields = exeClass.getDeclaredFields();
		for (Field field : fields) {
			field.setAccessible(true);
			if (!field.isAnnotationPresent(Inject.class)) {
				continue;
			}

			Field[] theseFields = CommandInterpreter.class.getDeclaredFields();
			for (Field thisField : theseFields) {
				thisField.setAccessible(true);
				if (!thisField.getType().equals(field.getType())) {
					continue;
				}

				field.set(exe, thisField.get(this));
			}
		}
	}
}
