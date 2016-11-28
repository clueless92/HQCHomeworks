package demos.dm02Commands.commands;

public class EndCommand extends Command {

	public EndCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		return "End";
	}
}
