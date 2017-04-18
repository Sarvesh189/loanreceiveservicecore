FROM microsoft/dotnet:onbuild
WORKDIR /app
Add  PublishOutput /app/
ENV ASPNETCORE_URLS http://*:5001
EXPOSE 5001
RUN dotnet restore
ENTRYPOINT ["dotnet","LoanReceivingService.dll"]