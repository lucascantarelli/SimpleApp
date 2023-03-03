# Path: .git/hooks/pre-commit
define git_pre_commit
#!/bin/sh
make format
endef
export git_pre_commit

# Path: .git/hooks/pre-push
define git_pre_push
#!/bin/sh
make test
endef
export git_pre_push

git-hooks:
	@if [ -d .git/hooks ]; then \
		echo "$$git_pre_commit" > .git/hooks/pre-commit; \
		echo "$$git_pre_push" > .git/hooks/pre-push; \
		chmod +x .git/hooks/pre-*; \
	fi

format:
	@echo "Formatting code..."
	@for dir in ls -d */; do \
		if [ ! $$dir = "ls" ] && [ ! $$dir = "-d" ]; then \
			rm -f $$dir"format-log.json"; \
			dotnet format $$dir --verbosity normal  --verify-no-changes --report $$dir"format-log.json"; \
		fi; \
	done

test:
	@dotnet test --no-build --verbosity normal