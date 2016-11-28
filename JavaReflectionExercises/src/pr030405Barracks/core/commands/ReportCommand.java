package pr030405Barracks.core.commands;

import pr030405Barracks.contracts.*;

public class ReportCommand extends Command {

	@Inject
	private Repository repository;

	public ReportCommand(String[] data) {
		super(data);
	}

	@Override
	public String execute() {
		String output = this.repository.getStatistics();
		return output;
	}
}
