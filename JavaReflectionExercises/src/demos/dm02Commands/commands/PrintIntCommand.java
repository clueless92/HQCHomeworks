package demos.dm02Commands.commands;

public class PrintIntCommand extends Command {

	protected PrintIntCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		int value = Integer.parseInt(this.getData()[1]);
		return Integer.toString(value) + " printed!";
	}
}
