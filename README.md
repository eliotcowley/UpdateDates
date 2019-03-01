# UpdateDates
I always forget to update the date field when I make edits to Microsoft documentation, and I wanted a way to have this done automatically whenever I add a file to a commit, so I wrote this program that updates the date field on any changed files to today's date.

You can add a PowerShell function to your **profile.ps1** file (usually in **C:\Users\<username>\Documents\WindowsPowerShell**) that both updates the dates and adds the files in one step:

```posh
function ud {
    C:\Path\To\Executable
    Write-Host "Adding files..."
    git add .
    Write-Host "Done!"
}
```

Now whenever you make changes to a file and are ready to commit, simply call `ud` instead of `git add`. Of course, instead of having to remember to update the dates manually, you have to remember to run `ud`, but it saves time when you have a bunch of files that have been changed.
