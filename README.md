# **Bandwidth Estimation Algorithm in Multi-device Experience Use Cases**

![Project Banner](https://via.placeholder.com/1200x300.png?text=Bandwidth+Estimation+Algorithm+in+Multi-device+Experience+Use+Cases)

## **Overview**

This project focuses on developing a **Bandwidth Estimation Algorithm** for various use cases involving multiple devices. The core objective is to create a robust system that can dynamically estimate the available bandwidth in both wired and wireless channels, ensuring optimal performance across different network conditions. 

The project involves building both a Windows application and an Android APK that communicate using TCP/UDP protocols to assess the channel's bandwidth. The data is transmitted between devices, and the system calculates the bandwidth based on the transmission and reception metrics.

## **Features**

- **Cross-Platform Communication:** Establish a TCP/UDP connection between a Windows PC and an Android device.
- **Dynamic Bandwidth Calculation:** Real-time estimation of bandwidth across various connection types (Wired, Wireless).
- **User-Friendly Interface:** Aesthetic and intuitive UI for easy interaction and control.
- **Extensive Testing:** Comprehensive testing with various network conditions to ensure accuracy and reliability.

## **Installation**

### **Windows Application**

1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/Bandwidth-Estimation-Algorithm.git
   ```
2. Navigate to the `PC App` directory:
   ```bash
   cd PC App/app
   ```
3. Build the solution in Visual Studio:
   - Open `app.sln` in Visual Studio.
   - Build the project by selecting `Build > Build Solution`.

4. Run the application:
   - Press `F5` or click on `Start Debugging`.

### **Android Application**

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/Bandwidth-Estimation-Algorithm.git
   ```
2. Open the project in Android Studio:
   - Navigate to the `Android APK` directory.
   - Open the project in Android Studio.

3. Build and run the APK:
   - Build the project by selecting `Build > Make Project`.
   - Deploy the APK to your Android device via USB or ADB.

## **Usage**

1. **Start the Windows Application:**
   - Launch the Windows application and select the desired connection mode (Wired/Wireless).

2. **Connect the Android Device:**
   - Launch the Android APK and ensure the device is connected to the same network as the PC.
   - Click on "Connect" to establish a connection.

3. **Start Streaming:**
   - Click on "Start Streaming" on the Windows application to begin data transmission.
   - The Android device will receive the data, and the bandwidth estimation will be displayed on the PC application.

4. **Stop Streaming:**
   - Click "Stop Streaming" to end the session.

## **Contributing**

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature-name`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature-name`).
5. Open a pull request.
