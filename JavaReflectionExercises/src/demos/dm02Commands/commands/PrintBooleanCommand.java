package demos.dm02Commands.commands;

public class PrintBooleanCommand extends Command {

	@Inject
	private StringBuilder builder;
	private int someInt;

	protected PrintBooleanCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		boolean value = Boolean.parseBoolean(this.getData()[1]);
		this.builder.append(Boolean.toString(value));
		return this.builder.toString();
	}
}
