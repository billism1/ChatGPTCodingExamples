#Fetch the latest from the git
git pull --prune

#Delete all local branches that have been merged to main branch
git branch -vv | where {$_ -match '\[origin/.*: gone\]'} | foreach { git branch -d $_.split(" ", [StringSplitOptions]'RemoveEmptyEntries')[0]}
