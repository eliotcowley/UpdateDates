# UpdateDates
I always forget to update the date field when I make edits to Microsoft documentation, and I wanted a way to have this done automatically whenever I add a file to a commit, so I wrote this program that updates the date field on any changed files to today's date.

Unfortunately you'll have to build the project on your own machine and create the executable since the gitignore combs that out. But once you do, you can call the program from the command line.

You can add a PowerShell function to your **profile.ps1** file (usually in **C:\Users\\\<username>\Documents\WindowsPowerShell**) that both updates the dates and adds the files in one step:

```posh
function ud {
    C:\Path\To\Executable
    Write-Host "Adding files..."
    git add .
    Write-Host "Done!"
}
```

Now whenever you make changes to a file and are ready to commit, simply call `ud` instead of `git add`. Of course, instead of having to remember to update the dates manually, you have to remember to run `ud`, but it saves time when you have a bunch of files that have been changed.

I'm bad at organization so there are three separate projects in here. The one you probably want is **UpdateDates**, but I'll explain them all just in case something else fits your needs:

* **RemoveMetadata**: Removes the "ms.prod" and "ms.technology" metadata from all files in the given folder. I think this was for some cleanup task a while back. Usage: `RemoveMetadata <path>`
* **UpdateDate**: Looks through the files you have changed but not yet added in git, updates their dates, and adds them in git. Usage: `UpdateDate`
* **UpdateDateFromFolder**: Updates the dates of all the files in the given folder. Usage: `UpdateDateFromFolder <path>`
