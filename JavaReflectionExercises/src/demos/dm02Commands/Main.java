package demos.dm02Commands;

import demos.dm02Commands.commands.*;

import java.io.*;

public class Main {

	public static void main(String[] args) throws IOException {
		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
		StringBuilder builder = new StringBuilder();
		Thread thread = new Thread();
		CommandInterpreter commandInterpreter = new CommandInterpreter(builder, thread);
		while (true) {
			String[] data = reader.readLine().split(" ");
			String commandName = data[0];
			Executable command = commandInterpreter.interpretCommand(commandName, data);
			String result = command.execute();
			if (result.equals("End")) {
				break;
			}
			System.out.println(result);
		}
	}
}
