package demos.dm02Commands.commands;

public class PrintDoubleCommand extends Command {

	@Inject
	private Thread decimalSpaces;

	public PrintDoubleCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		double value = Double.parseDouble(this.getData()[1]);
		return Double.toString(value) + " printed!";
	}
}
