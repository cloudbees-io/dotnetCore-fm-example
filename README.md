# Example .NET Core application for CloudBees platform feature management

Use this example application to integrate with the CloudBees platform and test feature management. After integrating, observe changes in the application UI as you update flag values in the CloudBees platform.

In this example, the Rox SDK is already set up, and feature flags are implemented in the code.

## Get started with the .NET Core project

To get started with the `dotnetCore-fm-example` project, follow these steps:

1. Using Git, clone the https://github.com/cloudbees-io/dotnetCore-fm-example repository to your local machine:

    ```shell
    git clone git@github.com:cloudbees-io/dotnetCore-fm-example.git
    ```

2. In your IDE (for example, Visual Studio, Rider, or Visual Studio Code), open the cloned repository as a .NET Core solution or project. You will revisit this project in your IDE later to run the application.

3. Locate and copy the SDK key:
    - Navigate to **Feature management > Flags**.
    - Select an application.
    - Select the copy button next to the SDK key on the page.

> **Note:**  
> If no SDK key is available:
>
> - Navigate to **Feature management > Flags**.  
> - Select **Install instructions** in the upper-right corner.  
> - Follow the installation steps. The SDK key appears once an application is linked to an environment.  
> - Close the installation instructions and copy the SDK key.

4. Add the SDK key to the application:

   - Open the `Demo/Program.cs` file:

     ```text
     Demo/Program.cs
     ```

   - Locate the SDK key placeholder in the file and replace it with your SDK key. For example:

     ```csharp
     var sdkKey = "<YOUR-SDK-KEY>";
     ```

5. Save the updated file.

6. Run the application from the repository root:

    ```shell
    dotnet run --project=Demo
    ```

7. To view the application running, go to `http://localhost:8080/demo` in your web browser.

## View the imported flags

Now that your application is running:

1. In the CloudBees platform, select **Feature management**.
2. Select your example application to display the available flags as shown in the table below.

### Feature flags in the example application

| Flag name     | Flag type | Description |
|---------------|-----------|-------------|
| `ShowMessage` | Boolean   | Turns the message on or off. |
| `Message`     | String    | Sets the message text. |
| `FontSize`    | Number    | Sets the message font size in pixels. Values: `12`, `16`, or `24`. |
| `FontColor`   | String    | Sets the message font color. Values: `red`, `green`, or `blue`. |

> **Note:**  
> If no flags are displayed, verify that the environment-specific SDK key is correctly added in:  
> `Demo/Program.cs`  
> Save the file, and restart the application.

**To update flags in the platform UI:**   

1. Select **Feature management** from the left pane.
2. Select the application.  
3. Select the vertical ellipsis next to the flag you want to configure.  
4. Select **Configure**.  
5. Select the **Environment** for the SDK key.  
6. Update a flag value and save your changes.  
7. Set the **Configuration status** to **On**.  

The updated flag value is reflected in the application display shortly.

## Use the application with multiple SDK keys

Run multiple instances of the SDK in a single application, each with its own SDK key and environment.  
Each instance is fully isolated.  
Use this when you need to read or compare flags across environments without redeploying, support multi-tenant routing, or combine server-side and client-side evaluations in one application.

To use multiple SDK keys in the example .NET Core application, follow these steps:

1. Retrieve the SDK keys for the environments you will use.
2. Initialize a separate SDK instance for each key.
3. Decide how to route requests to instances (for example, by tenant, region, or environment selector).
4. Perform register/fetch/stream setup on each instance as required by your SDK.
5. Evaluate flags using the selected instance. Pass a consistent user/context object for accurate targeting.
6. Tag logs or metrics by instance, and shut down instances you no longer need.

## Documentation reference

- For more information about using multiple SDK keys, refer to:  
  https://docs.cloudbees.com/docs/cloudbees-platform/latest/feature-management/use-multiple-sdk-keys

- For .NET/C# SDK installation details, refer to:  
  https://docs.cloudbees.com/docs/cloudbees-platform/latest/install-sdk/dot-net-c-sharp-sdk
